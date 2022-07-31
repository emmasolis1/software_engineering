// Emmanuel D. Solis.

function agregar() {
  var element = document.getElementById("lista");

  // One way to do it.
  const current_size = element.childElementCount;
  const new_element = "<li>Elemento"+(current_size + 1)+"</li>";
  element.innerHTML += new_element;

  // Another way to do it.
  // const new_element = document.createElement("li");
  // new_element.innerHTML = "Elemento " + (current_size + 1);
  // element.appendChild(new_element);
}

function borrar() {
  var element = document.getElementById("lista");
  element.removeChild(element.lastElementChild);
}

function cambiarFondo() {
  // Deprecated way to do it.
  // if (document.bgColor == "") {
  //   document.bgColor = "red";
  // } else {
  //   document.bgColor = "";
  // }

  // New correct way to do it.
  document.body.style.backgroundColor = document.body.style.backgroundColor == "" ? "orange" : "";
}