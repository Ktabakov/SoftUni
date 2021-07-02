class Story {
    _comments = [];
    _likes = [];
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
    }

    get likes() {
        if (this._likes <= 0) {
            return `${this.title} has ${this._likes.length} likes`;
        } else if (this._likes.length == 1) {
            return `${this._likes[0]} likes this story!`;
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
        }

    }
    like(username) {
        if (this._likes.includes(username)) {
            throw new Error(`You can't like the same story twice!`);
        } else if (this.creator == username) {
            throw new Error(`You can't like your own story!`);
        }
        else {
            this._likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }
    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error(`You can't dislike this story!`);
        } else {
            let index = this._likes.indexOf(username);
            if (index > -1) {
                this._likes.splice(index, 1);
            }
            return `${username} disliked ${this.title}`;
        }
    }
    comment(username, content, id) {
        let findComment = this._comments.find(x => x.id == id);
        if (id == undefined || findComment == undefined) {
            let commendId = this._comments.length;
            let newComment = {
                id: commendId,
                username: username,
                replies: [],
                content: content
            }
            newComment.replies.push({
                id: ``,
                username: ``,
                content: ``,
            });
            this._comments.push(newComment);
            return `${username} commented on ${this.title}`;
        } else {

            let allRepliesLenght = findComment.replies.length;
            findComment.replies.id = `${id}.${allRepliesLenght}`;
            findComment.replies.content = content;
            findComment.replies.username = username;
            return `You replied successfully`;
        }
    }

    toString(sortingType) {
        let sortingOrder = {
            "asc": (a, b) => a.id - b.id,
            "desc": (a, b) => b.id - a.id,
            "username": (a, b) => a.username.localeCompare(b.username)
        };

        let comments = [...this._comments.values()].sort(sortingOrder[sortingType]);
        comments.forEach(c => c.replies.sort(sortingOrder[sortingType]));

        let commentsStringArr = [];

        for (const comment of comments) {
            let commentsString = `--${comment.id}. ${comment.username}: ${comment.content}`;
            let repliesString = comment.replies.map(r => `--- ${r.id}. ${r.username}: ${r.content}`).join(`\n`)
            let combined = `${commentsString}\n${repliesString}`;

            commentsStringArr.push(combined);
        }

        let fullCommentString = commentsStringArr.join(`\n`)

        return `Title: ${this.title}
Creator: ${this.creator}
Likes: ${this._likes.length}
Comments: ${fullCommentString}`
    }

}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));

