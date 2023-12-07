# Postman
Postman API Test Automation
[Postman Quick Reference Guide and Cheat Sheet](https://postman-quick-reference-guide.readthedocs.io/en/latest/)
[Postman Old vs New Testing & Scripting Style Comparitive doc](./doc/Postman-old-and-new-testing-API.pdf)

![testing-overview](./doc/img/testing-overview.png)

## In this repository

1. [Overview.md](./doc/0-overiview.md)
    1. [API - Application Programming Interface](./doc/0-overiview.md#API--Application-Programming-Interface)
    2. [First API Call using Postman](./doc/0-overiview.md#First-API-Call-using-Postman)
    3. [Most common issues with Postman](./doc/0-overiview.md#Most-common-issues-with-Postman)
    4. [Postman web](./doc/0-overiview.md#Postman-web)
    5. [Http](./doc/0-overiview.md#Http)
    6. [Postman Landscape](./doc/0-overiview.md#Postman-Landscape)
    <br/>
2. [Creating REST API requests with Postman](./doc/1-rest-request-with-postman.md)
    1. [Storing Configuration in Variables](./doc/1-rest-request-with-postman.md#Storing-Configuration-in-Variables)
    1. [Modifying Collection variables](./doc/1-rest-request-with-postman.md#Modifying-Collection-variables)
    1. [Get Request](./doc/1-rest-request-with-postman.md#Get-Request)
    1. [Visualizing Response](./doc/1-rest-request-with-postman.md#Visualizing-Response)
    1. [Query Parameter](./doc/1-rest-request-with-postman.md#Query-Parameter)
    1. [Shortcuts](./doc/1-rest-request-with-postman.md#Shortcuts)
    1. [Path Variables](./doc/1-rest-request-with-postman.md#Path-Variables)
    1. [Post](./doc/1-rest-request-with-postman.md#Post)
    1. [GET vs POST](./doc/1-rest-request-with-postman.md#GET-vs-POST)
    1. [API Authentication](./doc/1-rest-request-with-postman.md#API-Authentication)
    1. [Using Random data in request](./doc/1-rest-request-with-postman.md#Using-Random-data-in-request)
    1. [Http Headers](./doc/1-rest-request-with-postman.md#Http-Headers)
    1. [Headers vs query param vs path param](./doc/1-rest-request-with-postman.md#Headers-vs-query-param-vs-path-param)
    1. [Sharing postman collection](./doc/1-rest-request-with-postman.md#Sharing-postman-collection)
    1. [Patch Request](./doc/1-rest-request-with-postman.md#Patch-Request)
    1. [HEAD Request Message](./doc/1-rest-request-with-postman.md#HEAD-Request-Message)
    <br/>

3. [Trello API Testing](./doc/2-trello-api.md)
<br/>

4. [API Test Scripts](./doc/3-test-scripts.md)
<br/>

5. [Test Scripts with Variables & Variables Scopes](./doc/4-test-scripts-with-variables.md)
    1. [Types of Variables](./doc/4-test-scripts-with-variables.md#Types-of-Variables)
    1. [Accessing variables in the scripts](./doc/4-test-scripts-with-variables.md#Accessing-variables-in-the-scripts)
    1. [Global Variables](./doc/4-test-scripts-with-variables.md#Global-Variables)
    1. [Environment Variables](./doc/4-test-scripts-with-variables.md#Environment-Variables)
    1. [Pre-request scripts](./doc/4-test-scripts-with-variables.md#Pre-request-scripts)
    1. [Variables types](./doc/4-test-scripts-with-variables.md#Variables---types)
    1. [Setup different URL to test against different environments](./doc/4-test-scripts-with-variables.md#Setup-different-URL-to-test-against-different-environments)
    1. [Debugging tests](./doc/4-test-scripts-with-variables.md#Debugging-tests)
<br/>

6. [Advance Assertions](./doc/5-advance-assertions.md)
    1. [Chai Assertion Library](./doc/5-advance-assertions.md#chai-assertion-library)
    1. [Assertions](./doc/5-advance-assertions.md#assertions)
    1. [Assertions on Array](./doc/5-advance-assertions.md#assertions-on-array)
    1. [Assertions on nested objects](./doc/5-advance-assertions.md#assertions-on-nested-objects)
    1. [Testing Headers & Cookies](./doc/5-advance-assertions.md#testing-headers--cookies)
<br/>

7. [Automatically running tests](./doc/6-automatically-running-tests.md)
    1. [Postman Collection runner](./doc/6-automatically-running-tests.md#postman-collection-runner)
    1. [Postman Monitor](./doc/6-automatically-running-tests.md#postman-monitor)
    1. [Automating with Newman](./doc/6-automatically-running-tests.md#automating-with-newman)
        1. [Installing new man](./doc/6-automatically-running-tests.md#installing-new-man)
        1. [Running a collection in postman](./doc/6-automatically-running-tests.md#running-a-collection-in-postman)
        1. [Accessing collections from newman](./doc/6-automatically-running-tests.md#accessing-collections-from-newman)
        1. [Specifying environments with newman](./doc/6-automatically-running-tests.md#specifying-environments-with-newman)
        1. [Generating Html reports from newman](./doc/6-automatically-running-tests.md#generating-html-reports-from-newman)
<br/>

8. [Workflows and scenarios](./doc/8-workflows-and-scenarios.md)
    1. [Multiple worksflows within same collection : https://www.youtube.com/watch?v=FWYKOR0Zj28](./doc/8-workflows-and-scenarios.md#multiple-worksflows-within-same-collection--httpswwwyoutubecomwatchvfwykor0zj28)