import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Principal from './containers/Principal/index'
import Produtos from './containers/Produtos/index'
import VisualizarProduto from './containers/VisualizarProduto/index'
import './styles/global.css'
import { BrowserRouter, createBrowserRouter, RouterProvider } from 'react-router-dom';
import CadastrarProduto from './containers/CadastrarProduto'

const router = createBrowserRouter([
  {
    path: "/",
    element: <Principal />
  },

  {
    path: "/produtos",
    element: <Produtos />
  },

  {
    path: "/visualizarproduto",
    element: <VisualizarProduto />
  },

  {
    path: "/cadastrarproduto",
    element: <CadastrarProduto />
  },
])

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
