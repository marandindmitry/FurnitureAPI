// Функция для отправки заказа
async function makeOrder() {
  const form = document.getElementById("order-form");
  form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const getValue = (name) =>
      parseInt(document.querySelector(`input[name="${name}"]:checked`).value);

    const deliveryType = getValue("deliveryType");
    const paymentOption = getValue("paymentOption");
    const customerName = document.getElementById("name").value;
    const customerPhoneNumber = document.getElementById("phone").value;
    const cityName = document.getElementById("city").value;

    const currentDate = new Date();
    const orderDate = currentDate.toISOString().split("T")[0];
    const deliveryDate = new Date(currentDate);
    const deliveryDateStr = deliveryDate.toISOString().split("T")[0];

    const orderRequest = {
      DeliveryType: deliveryType,
      PaymentOption: paymentOption,
      OrderDate: new Date(orderDate).toISOString(),
      DeliveryDate: new Date(deliveryDateStr).toISOString(),
      CustomerName: customerName,
      CustomerPhoneNumber: customerPhoneNumber,
      CityName: cityName,
    };

    const response = await fetch("http://localhost:5156/order/make-order", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(orderRequest),
    });

    if (response.ok) {
      alert("Заказ успешно оформлен!");
      form.reset();
    } else {
      alert("Ошибка при оформлении заказа.");
    }
  });
}

function handleSubmitButtonClick() {
  makeOrder();
}