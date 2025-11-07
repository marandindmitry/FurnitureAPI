async function loadFurnitureDetails(type, name) {
  const response = await fetch(`http://localhost:5156/furniture/${type}/${name}`);
  const furnitureDetail = await response.json();

  const productDetailsSection = document.createElement("section");
  productDetailsSection.classList.add("product-details");

  let additionalPropsHtml = ``;
  if (type === "Table") {
    additionalPropsHtml += `
      <p><strong>Глубина:</strong> ${furnitureDetail.depth} см</p>
      <p><strong>Высота от пола до обрамления:</strong> ${furnitureDetail.heightFloorToFrame} см</p>
    `;
  }

  productDetailsSection.innerHTML = `
    <img src="/Images/${furnitureDetail.fullImagePath}.jpg" alt="${furnitureDetail.name}" class="product-image">
    <div class="product-info">
      <h2>Название: ${furnitureDetail.name}</h2>
      <p><strong>Изготовитель:</strong> ${furnitureDetail.producer}</p>
      <p><strong>Материал:</strong> ${furnitureDetail.material}</p>
      <p><strong>Цвет:</strong> ${furnitureDetail.color}</p>
      <p><strong>Ширина:</strong> ${furnitureDetail.width} см</p>
      <p><strong>Высота:</strong> ${furnitureDetail.height} см</p>
      ${additionalPropsHtml}
      <p class="price">Цена: ${furnitureDetail.price} ₽</p>
      <button class="btn-primary" onclick="addFurnitureToCartById('${furnitureDetail.id}')">Добавить в корзину</button>
    </div>
  `;

  const mainContainer = document.querySelector("main");
  mainContainer.innerHTML = "";
  mainContainer.appendChild(productDetailsSection);
}

async function addFurnitureToCartById(id) {
  await fetch(`http://localhost:5156/furniture/${id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
  });
  alert('Товар добавлен в корзину');
}

