const cartContainer = document.getElementById('cart-container');
const totalPriceDiv = document.getElementById('total-price');
const totalAmountSpan = document.getElementById('total-amount');

updateShoppingCart();

async function updateShoppingCart() {
  const response = await fetch('http://localhost:5156/furniture/basket');
  const furnitureList = await response.json();

  cartContainer.innerHTML = '';

  let totalSum = 0;

  if (furnitureList.length === 0) {
    cartContainer.innerHTML = '<p class="empty-cart">Ваша корзина пуста.</p>';
    totalPriceDiv.style.display = 'none';
  } else {
    // Формирование карточек товаров
    furnitureList.forEach(f => {
      const card = document.createElement('div');
      card.classList.add('card');
      card.innerHTML = `
        <img src="/Images/${f.fullImagePath}.jpg" alt="${f.name}" class="card-image">
        <h3>${f.name}</h3>
        <p class="price">${f.price} ₽</p>
        <button class="remove-from-cart-btn" onclick="removeItemFromCart('${f.id}')">Удалить из корзины</button>
      `;
      cartContainer.appendChild(card);
      totalSum += parseFloat(f.price);
    });
    totalAmountSpan.textContent = totalSum.toFixed(2);
    cartContainer.style.display = 'block';
    totalPriceDiv.style.display = 'block';
  }
}

async function removeItemFromCart(id) {
  await fetch(`http://localhost:5156/furniture/basket/${id}`, {
    method: 'PUT',
  });
  updateShoppingCart();
}