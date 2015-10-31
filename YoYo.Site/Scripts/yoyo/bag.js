var step = 0;
var prepareCollapse = false;

var panel = $('#panel')[0]; //document.getElementById('panel');

panel.originalHeight = 250;
panel.style.height = "0px";
panel.style.display = "none";

$('#panelTitle')[0].onmouseover = show;
//document.getElementById('panelTitle').onmouseover = show;

$('#panelTitle')[0].onmouseout = onMouseOut;
//document.getElementById('panelTitle').onmouseout = onMouseOut;

//document.getElementById('panel').onmouseover = onMouseIn;
panel.onmouseover = onMouseIn;

//document.getElementById('panel').onmouseout = onMouseOut;
panel.onmouseout = onMouseOut;



function Move() {
    //var panel = document.getElementById('panel');
    var h = panel.clientHeight + step;
    panel.style.height = h + "px";

    if ((h + step <= panel.originalHeight && step > 0)
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
    if (panel.clientHeight < panel.originalHeight) {
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
    var table = $('#panel');
    table.empty();
    table.height(Math.min(cart.length, 3) * 105);
    for (var i = 0; i < cart.length; i++) {
        var divParent = $('<div></div>')
            .addClass('wrapper');

        //First column
        var divChild = $('<div></div>')
        .addClass('image');

        var image = $('<img />')
            .addClass("img")
            .attr("src", cart[i].image);

        divChild.append(image);
        divParent.append(divChild);

        //Second column
        divChild = $('<div></div>')
            .addClass("details");
        divParent.append(divChild);

        var pp = $('<p></p>')
            .addClass("Cena")
            .text(cart[i].price + '$');
        divChild.append(pp);

        pp = $('<p></p>')
            .addClass("Name")
            .text(cart[i].name);
        divChild.append(pp);

        pp = $('<p></p>')
            .addClass("Vid")
            .text(cart[i].description);
        divChild.append(pp);

        pp = $('<p></p>')
            .addClass("quantity")
            .text("Qty: " + cart[i].quantity);
        divChild.append(pp);

        //Three column
        divChild = $('<div></div>')
            .addClass("Remove");
        divParent.append(divChild);

        var btn = $('<span></span>')
            .attr('id', cart[i].id)
            .addClass("rem")
            .prop('title', 'Remove')
            .click(function () {
                $(cart[i].id).remove();
                location.reload();
            });

        divChild.append(btn);
        table.append(divParent);
    }

    if (cart.length > 0) {
        expandPanel();
    }
}

function findOrAddProduct(cart, productid) {
    for (var i = 0; i < cart.length; i++) {
        if (productid == cart[i].id) {
            return cart[i];
        }
    }
    var product = new Object();
    product.id = productid;
    product.image = document.getElementById("MainContent_imageBigPicture").getAttribute('src');
    product.name = $("#MainContent_labelProdectName").text();
    product.price = $("#MainContent_labelDescription").text();
    product.description = $("#MainContent_labelDescription1").text();

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

