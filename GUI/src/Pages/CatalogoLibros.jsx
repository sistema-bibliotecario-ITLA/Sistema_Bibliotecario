import React, { useState } from 'react';

const librosIniciales = [
  { id: 1, titulo: 'Cien años de soledad', autor: 'Gabriel García Márquez' },
  { id: 2, titulo: 'El principito', autor: 'Antoine de Saint-Exupéry' },
  { id: 3, titulo: 'Don Quijote de la Mancha', autor: 'Miguel de Cervantes' },
  { id: 4, titulo: '1984', autor: 'George Orwell' },
  { id: 5, titulo: 'Rayuela', autor: 'Julio Cortázar' },
];

const CatalogoLibros = () => {
  const [busqueda, setBusqueda] = useState('');

  const librosFiltrados = librosIniciales.filter(libro =>
    libro.titulo.toLowerCase().includes(busqueda.toLowerCase()) ||
    libro.autor.toLowerCase().includes(busqueda.toLowerCase())
  );

  return (
    <div className="container mt-4">
      <h2>Catálogo de Libros</h2>
      <input
        type="text"
        className="form-control my-3"
        placeholder="Buscar por título o autor..."
        value={busqueda}
        onChange={(e) => setBusqueda(e.target.value)}
      />

      <ul className="list-group">
        {librosFiltrados.length > 0 ? (
          librosFiltrados.map(libro => (
            <li key={libro.id} className="list-group-item">
              <strong>{libro.titulo}</strong> <br />
              <small className="text-muted">{libro.autor}</small>
            </li>
          ))
        ) : (
          <li className="list-group-item">No se encontraron libros</li>
        )}
      </ul>
    </div>
  );
};

export default CatalogoLibros;

