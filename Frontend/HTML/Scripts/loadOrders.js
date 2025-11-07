async function loadOrders() {
    const response = await fetch('http://localhost:5156/furniture/order-list');
    const items = await response.json();

    const container = document.getElementById('orders-container');
    const emptyOrders = document.getElementById('empty-orders');

    if (items.length === 0) {
        container.style.display = 'none';
        emptyOrders.style.display = 'block';
        return;
    }

    emptyOrders.style.display = 'none';
    container.style.display = 'block';
    container.innerHTML = '';

    const processedOrders = [];
    items.forEach(item => {
        const existingOrder = processedOrders.find(order => order.id === item.id);
        if (existingOrder) {
            existingOrder.items.push({
                name: item.name,
                price: item.price,
                fullImagePath: item.fullImagePath
            });
        } else {
            const orderDate = new Date(item.orderDate);
            const deliveryDate = new Date(orderDate);
            deliveryDate.setDate(deliveryDate.getDate() + 3);
            processedOrders.push({
                id: item.id,
                orderDate: orderDate.toLocaleDateString(),
                deliveryDate: deliveryDate.toLocaleDateString(),
                items: [{
                    name: item.name,
                    price: item.price,
                    fullImagePath: item.fullImagePath
                }]
            });
        }
    });

    processedOrders.forEach(order => {
        const total = order.items.reduce((sum, item) => sum + item.price, 0);
        const orderDiv = document.createElement('div');
        orderDiv.className = 'order-card';
        orderDiv.innerHTML = `
            <h3>Заказ №${order.id}</h3>
            <p><strong>Дата заказа:</strong> ${order.orderDate}</p>
            <p><strong>Дата получения:</strong> ${order.deliveryDate}</p>
            <h4>Товары:</h4>
            <div class="order-items">
                ${order.items.map(item => `
                    <div class="order-item">
                        <img src="/Images/${item.fullImagePath}.jpg" alt="${item.name}">
                        <div>
                            <p><strong>${item.name}</strong></p>
                            <p>Цена: ${item.price.toLocaleString()} ₽</p>
                        </div>
                    </div>
                `).join('')}
            </div>
            <p class="order-total"><strong>Общая сумма: ${total.toLocaleString()} ₽</strong></p>
        `;
        container.appendChild(orderDiv);
    });
}