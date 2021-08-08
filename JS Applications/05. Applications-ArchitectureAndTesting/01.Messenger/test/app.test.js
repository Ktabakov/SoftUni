const { chromium } = require('playwright-chromium');
const { expect } = require('chai');
let browser, page; // Declare reusable variables
let url = `http://127.0.0.1:5500/01.Messenger`;


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

let myMessage = {
    1: {
        author: `koko`,
        content: `Koko's Message`
    },
    2: {
        author: `pesho`,
        content: `pesho's message`
    }
}

let createMessage = {
    1: {
        author: `koko`,
        content: `Koko's CreatedMessage`,
        _id: 4
    },
}

describe('E2E tests', function () {
    before(async () => { browser = await chromium.launch({ headless: false }); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    describe(`LoadMessages`, () => {
        it(`Should Load Messages`, async () => {
            await page.route('**/jsonstore/messenger', route => route.fulfill(fakeResponce(myMessage)))

            await page.goto(url)

            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#refresh'),
            ]);

            let result = await response.json();
            expect(result).to.eql(myMessage);
        })
    })
    describe(`SubmitMessage`, () => {
        it(`Should Submit Messages`, async () => {
            
            let requestData = undefined;
            let expeced = {
                author: `koko`,
                content: `Koko's CreatedMessage`
            }
            await page.route('**/jsonstore/messenger', (route, request) => {
                if (request.method().toLowerCase() === `post`) {
                    requestData = request.postData();
                    route.fulfill(fakeResponce(createMessage))
                }
            })

            await page.goto(url)
            await page.fill(`#author`, expeced.author)
            await page.fill(`#content`, expeced.content)

            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#submit'),
            ]);
            let result = JSON.parse(requestData);
            expect(result).to.eql(expeced);
        })
    })
});
