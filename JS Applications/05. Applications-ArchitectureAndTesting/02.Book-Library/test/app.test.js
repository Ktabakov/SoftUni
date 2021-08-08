const { chromium } = require('playwright-chromium');
const { expect } = require('chai');
let browser, page; // Declare reusable variables
let url = `http://127.0.0.1:5500/02.Book-Library`;


function fakeResponce(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
}

let myBook = {
    1: {
        author: `koko`,
        title: `myBook`,
        _id: 1
    }
}
let createBook = {
    1: {
        author: `Stephen King`,
        title: `Misery`,
        _id: 1
    },
}
let updateBook = {
    1: {
        author: `Stephen King`,
        title: `Misery`
    },
}

describe('E2E tests', function () {
    before(async () => { browser = await chromium.launch({ headless: false, slowMo: 1000 }); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    describe(`loadBooks`, () => {
        it(`Should Load Books`, async () => {
            await page.route('**/jsonstore/collections/books', route => route.fulfill(fakeResponce(myBook)))

            await page.goto(url)

            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#loadBooks'),
            ]);

            let result = await response.json();
            expect(result).to.eql(myBook);
        })
    })
    describe(`submitBook`, () => {
        it(`Should Submit Book`, async () => {

            let requestData = undefined;
            let expeced = {
                author: `Stephen King`,
                title: `Misery`
            }
            await page.route('**/jsonstore/collections/books', (route, request) => {
                if (request.method().toLowerCase() === `post`) {
                    requestData = request.postData();
                    route.fulfill(fakeResponce(createBook))
                }
            })

            await page.goto(url)
            await page.fill(`#title`, expeced.title)
            await page.fill(`#author`, expeced.author)

            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#submit'),
            ]);
            let result = JSON.parse(requestData);
            expect(result).to.eql(expeced);
        })
    })
    
});