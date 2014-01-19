function showCheckoutBag() {
    var cart = getLocalStorageValue('Cart');
    var table = document.getElementById('checkoutTable');
    table.innerHTML = '';
    for (var i = cart.length - 1; i >= 0; i--) {
                           
        var image = document.createElement('img');
        image.src = cart[i].image;
        image.height = 100;
        image.width = 80;
        td = document.createElement('td');
        td.width = 200;
        td.appendChild(image);
        tr = document.createElement('tr');
        tr.appendChild(td);
        td = document.createElement('td');
        td.width = 200;
        td.appendChild(document.createTextNode(cart[i].name));
        tr.appendChild(td);
        td = document.createElement('td');
        td.width = 100;
        td.appendChild(document.createTextNode(cart[i].description));       
        tr.appendChild(td);
        
        td = document.createElement('td');
        td.width = 100;
        td.appendChild(document.createTextNode('Quantity: ' + cart[i].quantity));
        tr.appendChild(td);

        td = document.createElement('td');
        var btn = document.createElement('input');
        btn.id = cart[i].id;
        btn.type = 'button';
        btn.value = 'Delete';



        btn.addEventListener('click', function () {
            removeFromCart(this.id);
            location.reload();
        });

        td.appendChild(btn);
        tr.appendChild(td);          
        var tableRow = document.createElement('table');
        tableRow.className = 'inner';
        tableRow.appendChild(tr);
        table.appendChild(tableRow);
        
    }
}


