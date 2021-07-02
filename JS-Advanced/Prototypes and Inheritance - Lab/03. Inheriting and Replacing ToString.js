function toStringExtension() {
    class Person{
        constructor(name, email){
            this.name = name;
            this.email = email;
        }
        toString(end = `)`){
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email}${end}`;
        }
    }
    class Teacher extends Person{
        constructor(name, email, subject){
            super(name, email);
            this.subject = subject;
        }
        toString(){
            return super.toString(`, subject: ${this.subject})`);
        }
    }

    class Student extends Person{
        constructor(name, email, course){
            super(name, email);
            this.course = course;
        }
        toString(){
            return super.toString(`, course: ${this.course})`);
        }
    }

    // let person = new Person(`misho`, `mishak@gmail.com`);
    // let student = new Student(`gosho`, `gosho@22.com`, `C#` );
    // let teacher = new Teacher(`iva`, `iva2dsa@gmail.com`, `teach`);

    // console.log(person.toString());
    // console.log(student.toString());
    // console.log(teacher.toString());
    
    return {
        Person,
        Teacher,
        Student
    }
}

toStringExtension();