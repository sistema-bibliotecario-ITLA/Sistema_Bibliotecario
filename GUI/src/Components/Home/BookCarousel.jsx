import React from "react";
import { Carousel } from "react-bootstrap";

const BookCarousel = () => {
  return (
    <Carousel className="mb-5">
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://media.istockphoto.com/id/949118068/es/foto/libros.jpg?s=612x612&w=0&k=20&c=WL5xxQUeaRL9z6uHHYZD3CrXu-nlIRE9noRgviSSRd8="
          alt="Banner 1"
        />
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="https://imgs.search.brave.com/QwiATNKGj2JMGEaiGOdljxhyuMvRvByk1_A7oUqYGRc/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTM1/NDk4OTg0Mi9lcy9m/b3RvL2Jhbm5lci1j/b24tbGlicm9zLWFu/dGVjZWRlbnRlcy1l/bXByZXNhcmlhbGVz/LXktZWR1Y2F0aXZv/cy1jb25jZXB0by1k/ZS12dWVsdGEtYWwt/Y29sZS5qcGc_cz02/MTJ4NjEyJnc9MCZr/PTIwJmM9SXpqME5S/TjZrSVRXNnR4cTht/MGh4ejNlcFItblk3/UGlyQzd6SWs0MTlX/TT0"
          alt="Banner 2"
        />
      </Carousel.Item>
    </Carousel>
  );
};

export default BookCarousel;
