import React, { useState } from "react";
import "./LoginForm.css";

const SignIn = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Login:", { email, password });
  };

  return (
    <main className="form-signin text-center mt-5">
      <form
        onSubmit={handleSubmit}
        className="w-100 mx-auto"
        style={{ maxWidth: "330px", padding: "15px" }}
      >
        {/* Logo */}
        <img
          className="mb-4"
          src="https://images.vexels.com/media/users/3/267831/isolated/preview/cd079d709300f6af3cdfa75b83d35db8-winter-cozy-books-icon.png"
          alt="Biblioteca logo"
          width="72"
          height="57"
        />

        {/* Título */}
        <h1 className="h3 mb-3 fw-normal">Inicia sesión</h1>

        {/* Campo Email */}
        <div className="form-floating mb-2">
          <input
            type="email"
            id="floatingInput"
            className="form-control"
            placeholder="correo@ejemplo.com"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
          <label htmlFor="floatingInput">Correo electrónico</label>
        </div>

        {/* Campo Contraseña */}
        <div className="form-floating mb-3">
          <input
            type="password"
            id="floatingPassword"
            className="form-control"
            placeholder="Contraseña"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
          <label htmlFor="floatingPassword">Contraseña</label>
        </div>

        {/* Checkbox */}
        <div className="checkbox mb-3">
          <label>
            <input type="checkbox" value="remember-me" /> Recuérdame
          </label>
        </div>

        {/* Botón */}
        <button type="submit" className="w-100 btn btn-lg btn-primary">
          Ingresar
        </button>

        <a href="/signup" className="d-block mt-3">
          ¿No tienes cuenta? <b>Regístrate aquí</b>
        </a>

        {/* Pie de página */}
        <p className="mt-5 mb-3 text-muted">&copy; DDA COMPANY 2025</p>
      </form>
    </main>
  );
};

export default SignIn;
