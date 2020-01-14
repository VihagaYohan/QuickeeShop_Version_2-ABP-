var productDropDown = document.getElementsByClassName('orderItem-ProductId');
var row
var cell

var products = document.getElementById('productId') // products dropdown
var arr = Array.from(products); // array of products

// object array
var obj_Order = new Object();

// create order item object array
var arr_OrderItems = [];

// display unit price
products.addEventListener('change', function () {

	// unit price
	var unitPrice = arr[products.selectedIndex].dataset.unitPrice;
	document.getElementById('unitPrice').value = unitPrice

	// quantity
	var numProductCount = document.getElementById('quantity').value;

	// show line total
	lineTotal = numProductCount * unitPrice;

	// table row collection
	var rowCollection = document.getElementsByClassName('table-Row');

})

// add new order lines
btnAdd = document.getElementById('btnAdd');
btnAdd.onclick = hello

// calculate order line total
function calculateLineTotal(x) {
	cell = x.cellIndex

	console.log('cell index : ' + cell)


	row = x.parentElement.rowIndex
	row = row - 1; // target table row

	console.log('row index : ' + row)

	var table = document.getElementById('table-OrderItems')

	var quantity = table.children[row].children[3].children[0].value // line product quantity
	console.log('Quantity :' + quantity);

	var unitPrice = table.children[row].children[4].children[0].innerHTML // line product unit price
	console.log('Unit price : ' + unitPrice)

	var lineTotal = quantity * unitPrice;
	console.log(lineTotal)

	table.children[row].children[5].textContent = lineTotal // order line item total

	getTotalAmount();
}

// delete existing order lines
function DeleteOrderLines(x) {
	cell = x.cellIndex

	console.log('cell index : ' + cell)


	row = x.parentElement.rowIndex
	row = row - 1; // target table row

	console.log('row index : ' + row)

	var table = document.getElementById('table-OrderItems')
	table.deleteRow(row);

}

// calculate order line total for new order items
function CalcultateLineTotal(quantity, unitPrice) {
	
	var quantity = quantity;
	var unitPrice = unitPrice;

	var lineTotal = quantity * unitPrice;
	return lineTotal;
}

// calculate total order amount
function getTotalAmount() {
	var totalAmount = 0;
	var subTotal;
	var rowCollection;

	rowCollection = Array.from(document.getElementsByClassName('table-Row')) // array of order item table rows

	for (var i = 0; i < rowCollection.length; i++) {
		//subTotal = Number(rowCollection[i].children[4].innerHTML)
		subTotal = parseFloat(rowCollection[i].children[5].textContent)
		console.log(subTotal)
		totalAmount = totalAmount + subTotal;
	}

	document.getElementById('grandTotal').textContent = totalAmount;
}

// pass order object
var btnUpdate = document.getElementById('btnUpdate');
btnUpdate.onclick = updateOrder;

// sample method	
function world() {
	alert('Hello world')
}

// update order
function updateOrder(e) {
	e.preventDefault();

	// order id
	var order_Id = document.getElementById('orderId').innerText;

	// order date
	var orderDate = document.getElementById('orderDate').value;

	// customer id and customer name
	var customer = document.getElementById('customerId');

	var customerId = customer.options[customer.selectedIndex].value
	var customerName = customer.value;

	// get order items
	var tableRow = Array.from(document.getElementsByClassName('table-Row'))
	var arr_OrderItems = []; // array of order items

	/*var obj_OrderItems = new Object();*/ // order item object

	for (var i = 0; i < tableRow.length; i++) {
		var obj_OrderItems = {
			orderItemId: tableRow[i].children[0].value, // order item id
			productId: tableRow[i].children[1].innerText, // product id
			productName: tableRow[i].children[2].innerText, // product name
			quantity: tableRow[i].children[3].children[0].value, // quantity
			unitPrice: tableRow[i].children[4].innerText, // product unit price
			lineTotal: tableRow[i].children[5].textContent // line total
		}

		arr_OrderItems.push(obj_OrderItems) // add to order items object array
	}

	obj_Order.Id = order_Id;
	obj_Order.orderDate = orderDate;
	obj_Order.customerId = customerId;
	//obj_Order.customer = customer;
	obj_Order.orderItems = arr_OrderItems;
	obj_Order.totalAmount = document.getElementById('grandTotal').textContent;

	console.log(obj_Order);

	$.ajax({
		url: '/Order/Update',
		type: 'POST',
		dataType: "json",
		data: obj_Order,
		//success: function (response) {
		//	$("#dvtest").html(response);
		//}
	});

}

//var btnRemove = document.querySelector('#remove')
var btnRemove = document.querySelectorAll('.remove')
btnRemove.onclick = hello;


var buttonIndex = 0;

// sample method
function hello(e) {
	e.preventDefault();

	var table = document.getElementById("table-OrderItems");
	var row = table.insertRow(0);

	row.className = 'table-Row';

	// Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
	var orderItemId = row.insertCell(0);
	var productId = row.insertCell(1);
	var productName = row.insertCell(2);
	var quantity = row.insertCell(3);
	var unitPrice = row.insertCell(4);
	var lineTotal = row.insertCell(5);

	// create quantity input field
	var inputQuantity = document.createElement('input');
	//inputQuantity.id = "QtyId";
	inputQuantity.className = "form-control";
	inputQuantity.type = "number";
	inputQuantity.value = document.getElementById('quantity').value;

	// Add some text to the new cells:
	productId.innerHTML = arr[products.selectedIndex].value;
	productName.innerHTML = arr[products.selectedIndex].innerHTML;
	quantity.appendChild(inputQuantity);
	unitPrice.innerHTML = document.getElementById('unitPrice').value;
	lineTotal.innerHTML = document.getElementById('quantity').value * document.getElementById('unitPrice').value;

	var col = document.createElement('td');

	var btnDelete = document.createElement('button');
	btnDelete.className = 'btn-Delete btn btn-warning';
	btnDelete.innerText = 'Remove'
	btnDelete.id = buttonIndex;
	buttonIndex = buttonIndex + 1;

	col.appendChild(btnDelete)
	row.appendChild(col)

	getTotalAmount()

	// order item object
	var obj_OrderItem =
	{
		productId: productId.innerText,
		productName: productName.innerText,
		quantity: quantity.children[0].value,
		unitPrice: unitPrice.innerText,
		lineTotal: quantity.innerText * unitPrice.innerText
	};

	// adding order item object to array
	arr_OrderItems.push(obj_OrderItem);

	//btnDelete.onclick = getRowIndex
	btnDelete.onclick = deleteOrderLine
}

function deleteOrderLine(e) {
	e.preventDefault()
	var buttonId;

	e = e.target || e.srcElement;
	if (e.nodeName === 'BUTTON') {
		buttonId = e.id;

		var table_OrderItems = document.getElementById('table-OrderItems');
		var table_Row = document.getElementById(buttonId).parentElement.parentElement;

		table_OrderItems.deleteRow(table_Row);

		getTotalOrderAmount();
	}

}
