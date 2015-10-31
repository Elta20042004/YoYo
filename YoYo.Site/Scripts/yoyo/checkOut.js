function showCheckoutBag() {
    var cart = getLocalStorageValue('Cart');
    //var table = document.getElementById('checkoutTable');
    var table = $('#checkoutTable');
    table.innerHTML = '';
    for (var i = cart.length - 1; i >= 0; i--) {

        //var image = document.createElement('img');
        var image = $('<img />')
//image.src = cart[i].image;
        .attr("src", cart[i].image)
        .height(100)
        .width(80);

        //td = document.createElement('td');
        td = $('<td></td>')
        .width(200);
        td.append(image);
        //td.appendChild(image);

        //tr = document.createElement('tr');
        tr = $('<tr></tr>');
        tr.append(td);
        //tr.appendChild(td);

        //td = document.createElement('td');
        //td.width = 200;
        td = $('<td></td>')
        .width(200);
        td.append(td.text(cart[i].name));
        //td.appendChild(document.createTextNode(cart[i].name));
        //tr.appendChild(td);
        tr.append(td);

        td = $('<td></td>')
        .width(100);
        td.append(td.text(cart[i].description));
        tr.append(td);
        //td = document.createElement('td');
        //td.width = 100;
        //td.appendChild(document.createTextNode(cart[i].description));
        //tr.appendChild(td);

        td = $('<td></td>')
       .width(100);
        td.append(td.text('Quantity: ' + cart[i].quantity));
        tr.append(td);
        //td = document.createElement('td');
        //td.width = 100;
        //td.appendChild(document.createTextNode('Quantity: ' + cart[i].quantity));  
        //tr.appendChild(td);

        //td = document.createElement('td');
        //var btn = document.createElement('input');

        td = $('<td></td>');
        var btn = $('<input/>');
        btn.id = cart[i].id;
        btn.type = 'button';
        btn.value = 'Delete';

        btn.addEventListener('click', function () {
            removeFromCart(this.id);
            location.reload();
        });

        //td.appendChild(btn);
        //tr.appendChild(td);
        //var tableRow = document.createElement('table');
        //tableRow.className = 'inner';
        //tableRow.appendChild(tr);
        //table.appendChild(tableRow);
        td.append(btn);
        tr.appendd(td);
        var tableRow = $('<table></table>')
        .addClass('inner');
        tableRow.append(tr);
        table.append(tableRow);
    }
}


