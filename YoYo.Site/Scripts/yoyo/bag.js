var step = 0;
var prepareCollapse = false;
var panel = document.getElementById('panel');
panel.originalHeight = 250;
panel.style.height = "0px";
panel.style.display = "none";
document.getElementById('panelTitle').onmouseover = show;
document.getElementById('panelTitle').onmouseout = onMouseOut;
document.getElementById('panel').onmouseover = onMouseIn;
document.getElementById('panel').onmouseout = onMouseOut;

function Move() {
    var panel = document.getElementById('panel');
    var h = panel.clientHeight + step;
    panel.style.height = h + "px";

    if ((h + step <= panel.originalHeight && step >0)
        || (h + step >= 0 && step < 0)) {

        setTimeout("Move()", 5);
    }
    else {
        if (h + step < 0) {
            panel.style.display = "none";
        }
        step = 0;
    }
}
function execMove(nextMove) {
    var execNeeded = step == 0;
    step = nextMove;
    if (execNeeded) {
        Move();
    }
}

function expandPanel() {
    prepareCollapse = false;
    panel.style.display = "";
    if (panel.clientHeight  < panel.originalHeight) {
        execMove(5);
    }
}

function onMouseOut(event) {
    //this is the original element the event handler was assigned to
    if (event.relatedTarget != this && event.fromElement != this) {
        return;
    }
    if (!prepareCollapse) {
        prepareCollapse = true;
        setTimeout("collapsePanel()", 1000);
    }
    // handle mouse event here!
}

function onMouseIn(event) {
    //this is the original element the event handler was assigned to
    if (event.relatedTarget != this && event.toElement != this) {
        return;
    }
    expandPanel();
    // handle mouse event here!
}

function collapsePanel() {
    if (prepareCollapse) {
        prepareCollapse = false;
        execMove(-5);
    }
}



function show() {
    var cart = getLocalStorageValue('Cart');
    var table = document.getElementById('panel');
    table.innerHTML = '';
    table.originalHeight = Math.min(cart.length, 3) * 105;
    for (var i = 0, tr, td; i < cart.length; i++) {
        tr = document.createElement('tr');
        td = document.createElement('td');
        var image = document.createElement('img');
        image.src = cart[i].image;
        //image.src = "Images/Products/Icon/03.jpg";
        image.height = 100;
        image.width = 80;
        td.appendChild(image);
        td.appendChild(document.createTextNode(cart[i].name));
        td.appendChild(document.createTextNode(cart[i].description));

        //?????????????????????????????????????????????????
        var btn = document.createElement('input');
        btn.id = cart[i].id;
        btn.type = 'button';
        btn.value = 'Delete';

        btn.addEventListener('click', function () {
            
            removeFromCart(this.id);
            location.reload(showCheckoutBag);
        });
        // btn.setAttribute('onclick', 'table.removeChild(table)');


        tr.appendChild(td);
        tr.appendChild(btn);
        table.appendChild(tr);
        

    }

    if (cart.length > 0) {
        expandPanel();
    }
}

function findOrAddProduct(cart,productid) {
    for (var i = 0; i < cart.length; i++) {
        if (productid == cart[i].id) {
            return cart[i];
        }
    }
    var product = new Object();
    product.id = productid;
    product.image = document.getElementById("MainContent_imageBigPicture").getAttribute('src');
    product.name = $("#MainContent_labelProdectName").text();
    product.description = $("#MainContent_labelDescription").text();
    product.description1 = $("#MainContent_labelDescription1").text();
    
    product.quantity = 0;
    cart.push(product);
    return product;
}

function addToCart() {
    var productid = getParameterByName('productID');
    var cart = getLocalStorageValue('Cart');
    var count = parseInt($("#leaveCode")[0].value);
    var product = findOrAddProduct(cart, productid);
    product.quantity += count;
    setLocalStorageValue('Cart', cart);
    show();
}

function removeFromCart(productId) {
    var cart = getLocalStorageValue('Cart');
    //remove
    var cartNew = [];

    for (var i = 0; i < cart.length; i++) {
        if (productId != cart[i].id) {
            cartNew.push(cart[i]);
        }    
    }

    setLocalStorageValue('Cart', cartNew);
    show();
}

