import React from "react";
import { Card, Button } from "react-bootstrap";

const BookCard = ({ book, onRent, onSave }) => {
  return (
    <Card className="h-100 shadow">
      <Card.Img
        variant="top"
        src={book.image}
        style={{ height: "300px", objectFit: "cover" }}
      />
      <Card.Body>
        <Card.Title>{book.title}</Card.Title>
        <Card.Text>Autor: {book.author}</Card.Text>
        <div className="d-flex justify-content-between">
          <Button variant="primary" onClick={() => onRent(book)}>
            Alquilar
          </Button>
          <Button variant="outline-secondary" onClick={() => onSave(book)}>
            Guardar
          </Button>
        </div>
      </Card.Body>
    </Card>
  );
};

export default BookCard;
