async function loadAllFurnitureByType(type) {
    const response = await fetch(`http://localhost:5156/furniture/${type}`);
    const furnitureList = await response.json();

    const container = document.getElementById('carts');
    container.innerHTML = '';

    let heroTitle, heroDescription;
    if (type === 'Table') {
        heroTitle = 'Каталог столов';
        heroDescription = 'Выберите идеальный стол для вашего дома или офиса.';
    } else if (type === 'Chair') {
        heroTitle = 'Каталог стульев';
        heroDescription = 'Выберите идеальный стул для вашего дома или офиса.';
    }

    const heroSection = document.querySelector('.hero');
    if (heroSection) {
        heroSection.innerHTML = `
            <h1>${heroTitle}</h1>
            <p>${heroDescription}</p>
        `;
    }

    furnitureList.forEach(f => {
        const card = document.createElement('div');
        card.classList.add('card');

        card.innerHTML = `
            <img src="/Images/${f.fullImagePath}.jpg" alt="${f.name}" class="card-image">
            <h3>${f.name}</h3> 
            <p>${f.description}</p>
            <p class="price">${f.price} ₽</p>
            <a href="furniture-details.html?type=${type}&name=${f.name}">
                <button class="card-btn">Подробнее</button>
            </a>
        `;

        container.appendChild(card);
    });
}
