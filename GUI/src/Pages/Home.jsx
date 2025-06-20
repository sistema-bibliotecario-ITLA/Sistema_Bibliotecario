import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import BookCard from "../Components/Home/BookCard";
import BookCarousel from "../Components/Home/BookCarousel";
import AppNavbar from "../Components/Home/NavBar";

// estos son ejemplos para que puedas usarlos, no los borres en la app eso vendra de la base de datos
//trabaja con eso, puedes agreagar mas si gustas, para que pruebes
const books = [
  {
    id: 1,
    title: "Cien Años de Soledad",
    author: "Gabriel García Márquez",
    image: "https://imgs.search.brave.com/CqqsVlJsLYCDtA1yB7GNYrMfbhfTpAdVYD2PHu6zP8A/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tLm1l/ZGlhLWFtYXpvbi5j/b20vaW1hZ2VzL0kv/NTFmZkdLWmg3Vkwu/anBn",
  },
  {
    id: 2,
    title: "1984",
    author: "George Orwell",
    image: "https://imgs.search.brave.com/LPbYIH3pUVvHb0CC4tDGMGPD66pwQI35YrY1w6ldAHQ/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly93d3cu/cGVuZ3Vpbi5jby51/ay9fbmV4dC9pbWFn/ZT91cmw9aHR0cHM6/Ly9jZG4ucGVuZ3Vp/bi5jby51ay9kYW0t/YXNzZXRzL2Jvb2tz/Lzk3ODAxNDEwMzYx/NDQvOTc4MDE0MTAz/NjE0NC1qYWNrZXQt/bGFyZ2UuanBnJnc9/NjE0JnE9MTAw.jpeg",
  },
  {
    id: 3,
    title: "El Principito",
    author: "Antoine de Saint-Exupéry",
    image: "https://imgs.search.brave.com/cK0souniwvxsExgaiwxPkWvuQ2qP3ham6j3tXWXV0Gg/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9pNS53/YWxtYXJ0aW1hZ2Vz/LmNvbS9zZW8vRWwt/UHJpbmNpcGl0by1Q/YXBlcmJhY2stOTc4/MTkzNzQ4Mjk3OF8z/MzhjOTM0ZS1jNDRj/LTRhMWYtYjRlMi1j/NjdhY2MzNTE3MWYu/NGUxNzYzZjJlOWMy/ZTBkYmQ3NWI3NzI4/M2IzNjc5NTUuanBl/Zz9vZG5IZWlnaHQ9/NTgwJm9kbldpZHRo/PTU4MCZvZG5CZz1G/RkZGRkY",
  },
];

const Home = () => {
  const handleRent = (book) => {
    alert(`Alquilaste: ${book.title}`);
  };

  const handleSave = (book) => {
    alert(`Guardaste: ${book.title}`);
  };
// estos son componentes que puedes reutilizar, no los borres, puedes agregar mas si gustas
  return (
    <Container className="mt-4">
      <BookCarousel />
      <h2 className="mb-4 text-center">Libros Disponibles</h2>
      <Row xs={1} md={3} className="g-4">
        {books.map((book) => (
          <Col key={book.id}>
            <BookCard book={book} onRent={handleRent} onSave={handleSave} />
          </Col>
        ))}
      </Row>
    </Container>
  );
};

export default Home;
