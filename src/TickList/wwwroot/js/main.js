


function newTickItem(id,text) {

    var msg, content

    article = document.createElement("article")

    article.className = "tickItem"
    article.id = id
    msg =  '    <p>' + text + '</p>'
    msg += '    <input type="checkbox" id="item' + id + '" class="box"/>'
    msg += '    <lable for="item' + id + '" class="tab"/>'


    article.innerHTML = msg

    console.log(article)

    
    
    content = document.getElementById("content")

    content.appendChild(article)

}

newTickItem(4,'This is a new item')