var TickList, Inputs

function newTickItemDom(id,text,completed) {
/*
    18/01/2017
    Created a new tick item and appends to the DOM.

*/
    var msg, content, article, inputDom

    article = document.createElement("article")

    article.className = "tickItem"
    article.id = "tick"+id
    msg =  '<p>' + text + '</p>'
    msg += '<input type="checkbox" onclick="handleClick(this)" id="item' + id + '" class="box"/>'
    msg += '<label for="item' + id + '" class="tab"/>'

    article.innerHTML = msg

    inputDom = article.childNodes[1]

    inputDom.checked = completed

    content = document.getElementById("content")

    content.appendChild(article)

}

/*
newTickItemDom(1,'This is a new item')
newTickItemDom(2,'This is a new item')
*/

function getIDFromClass(className) {
    return className.replace("item","")
}


function handleClick(inputItem){

    var tickID, domObject, tickItem

    tickID = getIDFromClass(inputItem.id)

    console.log("tickID: "+tickID)

    TickList.map(function(x){
        if (x.tickItemID == tickID) {
            x.completed = !x.completed

            tickItem = x
        }
    })

    console.log(tickItem)

    pushTickListToApi(tickItem)

}


function getTickItemFromDom(id) {
/*
    18/01/2017
    Obtains a TickItem via ID, or the TickArray from the DOM.
*/
    var domObject 

    if (id) {
        domObject = document.getElementById("tick"+id)
    }
    else {
        domObject = document.getElementsByClassName("tickItem")
    }

    return domObject

}

function deleteTickItemFromDom(id){
/*
    18/01/2017
    deletes a tick item from the DOM via the ID
*/
    var domObject

    domObject = getTickItemFromDom(id)
    domObject.remove()
}

function getTickListFromApi(){

    var req

    function responseListener () { 

        var resp

        resp = JSON.parse(this.responseText)

        resp.map(function(x){
            TickList.push(x)
            newTickItemDom(x.tickItemID, x.title, x.completed)
        })
    }

    req = new XMLHttpRequest

    req.addEventListener("load", responseListener);

    req.open("GET","api/Tick")
    req.send()

}

function pushTickListToApi(TickItem) {

    var req


    function logResult(){
        console.log("post completed")
        console.log(this)
    }

    req = new XMLHttpRequest

    req.addEventListener("load", logResult);

    req.open("PUT","api/Tick/"+TickItem.tickItemID)

    req.setRequestHeader("Content-type", "application/json")

    jsonBlob = JSON.stringify(TickItem)

    req.send(jsonBlob)
}

function postItem(){
    var text, post, id, get

    function getItem(){

        function loadItem() {
            var resp

            resp = JSON.parse(this.responseText)
            console.log(resp)
            TickList.push(resp)
            newTickItemDom(resp.tickItemID, resp.title, resp.completed)
        }


        id = document.getElementsByClassName("tickItem").length + 1

        console.log("debug: id "+id+" text: "+text)

        get = new XMLHttpRequest
        get.open("GET","api/Tick/"+id)
        get.setRequestHeader("Content-Type", "application/json");
        get.addEventListener("load", loadItem);
        get.send()


    }





    text = document.getElementById("newItem").value
    post = new XMLHttpRequest

    post.open("POST","api/Tick",true)
    post.setRequestHeader("Content-Type", "application/json");
    post.addEventListener("load",getItem)
    post.send(JSON.stringify(text))


}

TickList = new Array

getTickListFromApi()

