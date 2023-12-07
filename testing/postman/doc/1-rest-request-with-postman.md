# Creating REST API requests with Postman
* A postman `collection` is a place where we can store our requests. 
* A postman `request` will have default name of URL but it is good to give meaningful names. If we can any changes to collection/request we need to save this as well. 

## Storing Configuration in Variables
* let say we have 20 request in a collection and base url changes so it is good to store it in variable. 
* If you select a text then postman would be pop an option to set it as variable.
![variable](./img/variable-1.png)
![variable](./img/variable-2.png)
* We can choose the scope of the variable. 
* **Variable syntax**: `{{variableName}}`
* You need to save request after creating a variable

## Modifying Collection variables
* You need to go to this collection by clicking on the 3 dots when you hover over collection name then from context menu click on edit. 
* Then you can go to variables tab and edit the variable
![variable](./img/variable-3.png)
* The `initial-value` will be used when you share the collection. The `current-value` is a local private variable for your collection visible to only you even if team is collaborating on same collection. 
* If your variable has secret data then you can set some dummy initial value.

## Get Request
* `Endpoint`: Address of the url where you are sending the request. 
* `Resources`: With REST we deal with resources like here product is resource. 
![get](./img/get.png)

## Visualizing Response
* In your `Body` section in postman-gui we have options like **pretty, raw, review, visualize**
* It has has by default json formatting selected. 
* **Preview** makes sense with different types of data from any endpoint. Eg make get request to netflix.com
![img](./img/Screenshot%202022-09-02%20135452.png)

## Query Parameter
* Casing it important for the query parameters. 
* **Syntax**: `?<param_name>=<value>&<param_name2>=<value2>...`
* if a query param is options and you send wrong param then api doesn't report error. 
![query-param](./img/query-param.png)


## Shortcuts
* Go to gear icons in top right then go to shortcuts, then you can go to shortcuts tab. 
![ShortCuts](./img/Shortcuts.png)

## Path Variables
* **Syntax**: `baseurl/<endpoint>/:pathParamName=pathParamValue`
<br/>
![img](./img/Path.png)

# Post
* In below sample we are going to make a post request for no body. The status would return 201 Created. 
![cart](./img/cart.png)
![cart](./img/cart-add-item.png)


## GET vs POST 
![Get-vs-Post](./img/Get-vs-Post.png)

# API Authentication
* First you need to figure out authenticate mechanism for API and get the right access token, client-id, client-secret, username, password , ect
* Sample Call to get access token 
![access token](./img/access-token-call.png)
* Then we can go to collection and store it in variable, because access-token is a secret data , the initial value we can keep empty or give a message 
![session variable](./img/storing-access-token.png)
* Then all we need to do it pass it to the API call using the right mechanism for this we can go to the authorization tab. 
![Passing Bearer Token](./img/passing-token.png)

## Using Random data in request
* To pass a random data in body start with {{$ and it will give you suggestions for all random data generator functions available. 
![random-data](./img/random-data.png)
* You can see in console output the body for the request send has a randomly generated name. 
![image.png](./img/random2.png)

## Http Headers 
* **Content-Type**: Telling api what type of request we are sending to API 
* Responses also have headers which are returned by the API. 
* headers are key value pair. 
![Headers](./img/Headers.png)
* Headers are used instead of body as they are intended to provide some additional information about the message we sent to api and adding this data to body will clog the body and make it have unnecessary attributes in body.
* Postman automatically adds most typical headers we need. 

### Headers vs query param vs path param 
* Query param and path param are about resource addresses. 

## Sharing postman collection 
* We have multiple options to share, one of them being sharing collection via link 
![Sharing](./img/Sharing.png)
* You can also export the collection. 

## Patch Request
* Patch means to fix/repair something.
![patch](./img/patch.png)
![patch2.png](./img/patch2.png)

## HEAD Request Message
* This is a special http method, it doesn't have request/response body but it is a way to check if API is up and running without having to send an heavy request