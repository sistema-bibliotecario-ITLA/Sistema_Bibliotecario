import { useState } from 'react'
import reactLogo from './assets/react.svg'
import LoginForm from './Components/Login/LoginForm'
import SignUp from './Components/SignUp/SignUpForm'
import Home from './Pages/Home'
import viteLogo from '/vite.svg'
import './App.css'
import {BrowserRouter, Routes, Route} from "react-router-dom"
import "bootstrap/dist/css/bootstrap.min.css"
import AppNavbar from './Components/Home/NavBar'

function App() {

  return (
    <>
    <BrowserRouter>
      <AppNavbar />
        <Routes>
          <Route path="/login" element={<LoginForm />} />
          <Route path="/signup" element={<SignUp />} />
          <Route path="/" element={<Home />} />
        </Routes>
    </BrowserRouter>

    </>
  )
}
import CatalogoLibros from './Pages/CatalogoLibros';

export default App
