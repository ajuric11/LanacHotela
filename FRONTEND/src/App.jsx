import { useState } from 'react'
import reactLogo from './assets/react.svg'
import mojLogo from '/vite.svg'
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import NavBar from './components/NavBar'
import { Route, Routes } from 'react-router-dom'
import { RoutesNames } from './constants'
import Pocetna from './pages/Pocetna'
import Soba from './pages/sobe/Sobe'
import SobeDodaj from './pages/sobe/SobeDodaj'
import SobePromjena from './pages/sobe/SobePromjena'
import Sobe from './pages/sobe/Sobe'

function App() {


  return (
    <>
      <NavBar />
      <Routes>
        <Route path={RoutesNames.HOME} element={<Pocetna />} />
        <Route path={RoutesNames.SOBA_PREGLED} element={<Sobe/>} />
        <Route path={RoutesNames.SOBA_NOVI} element={<SobeDodaj />} />
        <Route path={RoutesNames.SOBA_PROMJENI} element={<SobePromjena />} />
      </Routes>
    </>
  )
}

export default App