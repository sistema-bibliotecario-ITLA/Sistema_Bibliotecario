import React, { useState } from "react";
import {useNavigate} from "react-router-dom"
import {signUp} from "../../API/auth";

const Register = () => {
  const [namee, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirm] = useState("");
  const navigate = useNavigate();
  const handleSubmit = async (e) => {
    e.preventDefault();

    if(password !== confirmPassword){
      alert("las contrase?as no coinciden")
      return;
    }

    const body = {
      name: namee,
      email: email,
      password: password,
      role: "Client"
    };

    try {
      const data = await signUp({body})
      console.log("Se guardo el nuevo usuario");
      alert("su Cuenta ha sido creada");

      navigate("/login");
    } catch(err){
      console.log("error: ", err);
      alert(err);
    }
  };

  return (
    <main className="form-signin text-center mt-5">
      <form
        onSubmit={handleSubmit}
        className="w-100 mx-auto"
        style={{ maxWidth: "330px", padding: "15px" }}
      >
        <img
          className="mb-4"
          src="https://images.vexels.com/media/users/3/267831/isolated/preview/cd079d709300f6af3cdfa75b83d35db8-winter-cozy-books-icon.png"
          alt="Biblioteca logo"
          width="72"
          height="57"
        />

        <h1 className="h3 mb-3 fw-normal">Crea una cuenta</h1>

        {/* Nombre */}
        <div className="form-floating mb-2">
          <input
            type="text"
            name="name"
            className="form-control"
            id="floatingName"
            placeholder="Nombre completo"
            value={namee}
            onChange={(e) => setName(e.target.value)}
            required
          />
          <label htmlFor="floatingName">Nombre completo</label>
        </div>

        {/* Correo */}
        <div className="form-floating mb-2">
          <input
            type="email"
            name="email"
            className="form-control"
            id="floatingEmail"
            placeholder="nombre@ejemplo.com"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
          <label htmlFor="floatingEmail">Correo electrónico</label>
        </div>

        {/* Contraseña */}
        <div className="form-floating mb-2">
          <input
            type="password"
            name="password"
            className="form-control"
            id="floatingPassword"
            placeholder="Contraseña"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
          <label htmlFor="floatingPassword">Contraseña</label>
        </div>

        {/* Confirmar contraseña */}
        <div className="form-floating mb-3">
          <input
            type="password"
            name="confirmPassword"
            className="form-control"
            id="floatingConfirmPassword"
            placeholder="Confirmar contraseña"
            value={confirmPassword}
            onChange={(e) => setConfirm(e.target.value)}
            required
          />
          <label htmlFor="floatingConfirmPassword">Confirmar contraseña</label>
        </div>

        <button className="w-100 btn btn-lg btn-primary" type="submit">
          Registrarse
        </button>

        <a href="/login" className="d-block mt-3">
          ¿Ya tienes una cuenta? <b>Inicia sesión aquí</b>
        </a>

        <p className="mt-5 mb-3 text-muted">&copy; DDA COMPANY 2025</p>
      </form>
    </main>
  );
};

export default Register;
