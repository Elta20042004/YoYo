function showRV() {
    var rV = getLocalStorageValue('RecentlyViewed');
    var outerTr = document.getElementById('PanelRV');
    outerTr.innerHTML = '';
    for (var i = rV.length-1; i >=0 ; i--) {
        var image = document.createElement('img');
        image.src = rV[i].image;
        image.height = 100;
        image.width = 80;
        var a = document.createElement('a');
        a.href = 'Prod.aspx?productID=' + rV[i].id;
        a.appendChild(image);
        var div = document.createElement('div');
        div.appendChild(a);
        var td = document.createElement('td');
        td.appendChild(div);

        outerTr.appendChild(td);
    }
}
    
function addToRV() {
    var product = new Object();
    product.id = getParameterByName('productID');
    product.image = document.getElementById('MainContent_imageBigPicture').getAttribute('src');  

    var rV = getLocalStorageValue('RecentlyViewed');
    var i = 0;
    while (i<rV.length  &&  product.id != rV[i].id  ) {
        i++;
    }
    if (i == rV.length) {
        // tochno znaem chto net elementa
        rV.push(product);
    }
    if (rV.length - 8 > 0) {
        rV.splice(0, rV.length - 8);
    }
    setLocalStorageValue('RecentlyViewed', rV);
}