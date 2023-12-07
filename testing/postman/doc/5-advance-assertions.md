# Advance Assertions
* Postman internally uses chai testing framework

* **Parsing response body**:
    * JSON -> `pm.response.json()`
    * XML -> `xml2json(responseBody)`
    * HTML -> `cheerio(pm.response.text())` cheerio allows us to work with DOM 
    * Plain text -> `pm.response.text()`
    * CSV -> `csv-parse/lib/sync` is the built in library for this. 

## Chai Assertion Library 
* Chai is a simple behavior driven human understandable assertion library. eg: `expect([]).to.be.an('array').that.is.empty`
* [Chai Docs](https://www.chaijs.com/api/bdd/)

## Assertions 
* Adding error message to reports.
```js
pm.test("Your test name", function(){
    pm.expect(100).to.eql(100, 'Text which will be included in output/report if this test fails')
})
```
* Working with objects and array and strings
```js
pm.test("Testing object", function(){
    let a = {
        "name" : "abhishek"
    }
    let b = {
        "name" : "abhishek"
    }

    pm.expect(a).to.eql(b) //test passes
    pm.expect(a).to.equal(b) //test fails as it will check if object has same reference. 
    pm.expect(a).to.not.equal(b) // test passes

    let c = let b = {
        "name" : "abhishek", 
        "userName" : "abhishek01"
    }
    pm.expect(a).to.eql(c) //test fails
    pm.expect(a).to.not.eql(c) //test passes

    pm.expect([]).to.be.empty // test passes
    pm.expect([1, 2, 3]).to.include(4) // test fails
    pm.expect(2).to.be.oneOf([1,2,3]) // test passes

    // String & Regex 
    pm.expect('Abhishek Gautam').to.match(/^Abhishek/); //pass 

})
```

## Assertions on Array 

* Mock response body used: 
```json
{
"companyId": 10101,
"regionId": 36554,
"filters": [
    {
    "id": 101,
    "name": "VENDOR",
    "isAllowed": false
    },
    {
    "id": 102,
    "name": "COUNTRY",
    "isAllowed": true
    },
    {
    "id": 103,
    "name": "MANUFACTURER",
    "isAllowed": false
    }
]
}
```

* Test 

```js
let jsonData = pm.response.json();
let manufacturer;

for(let filter of jsonData.filters){
    if(filter.name === 'MANUFACTURER')
        manufacturer = filter;
}

pm.test("Manufacturer should not be allowed", function(){
    pm.expect(manufacturer.name).to.eql("MANUFACTURER");
    pm.expect(manufacturer.isAllowed).to.be.false
})

```

## Assertions on nested objects

* Json data used for this 
```json
{
"id": "5ab34c7b0ba0f8932222352c",
"name": "My board 7",
"prefs": {
    "permissionLevel": "private",
    "voting": "disabled",
        "comments": {
        "status": "disabled",
        "count": 0
        }
    },
"limits": {
    "54bba24af6196bd5f824e563": {
        "boards": {
            "totalPerMember": {
                "count": 1,
                "status": "ok",
                "disableAt": 56050,
                "warnAt": 53100
                }
            }
        }
    }
}
```

* Test 
```js
let jsonData = pm.response.json()

let commentStatus = jsonData.prefs.comments.status;

pm.test("Comments should be disabled", function(){
    pm.expect(commentsStatus).to.eql("disabled")
})

let boardStatus;

for(let key in jsonData.limits){ // iterating object properties
    if(jsonData.limits[key].hasOwnProperty('boards')){
        boardStatus = jsonData.limits[key].boards.totalPerMember.status;
    }
}

pm.test("status should be ok", function(){
    pm.expect(boardStatus).to.eql("ok")
})
```

## Testing Headers & Cookies
* This is how you retrieve a header from the response: `pm.response.headers.get('X-Cache') ` and in a test:
    * **Header exists**: `pm.response.to.have.header(X-Cache'); `
    * **Header has value**: `pm.expect(pm.response.headers.get('X-Cache')).to.eql('HIT');` 

* **Cookies**: In a similar fashion you can test cookies as well.
    * **Cookie exists**: `pm.expect(pm.cookies.has('sessionId')).to.be.true;`
    * **Cookie has value**: `pm.expect(pm.cookies.get('sessionId')).to.eql(’ad3se3ss8sg7sg3');`