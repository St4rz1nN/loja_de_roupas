import styled from "styled-components";
import { Link } from 'react-router-dom';

export const Container = styled.div `
    height: 100px;
`

export const ContentPrincipal = styled.div `
    background-color: rgb(0,0,0,1);
    height: 100px;
    display: flex;
    justify-content: space-between;
    position: fixed;
    z-index: 2;
`

export const ContentTitle = styled.div `
    width:800px;
`

export const Title = styled(Link) `
    display: flex;
    padding-left: 30px;
    align-items: center;
    color: white;
    font-size: 30px;
    cursor: pointer;
    text-decoration: none;
`

export const Menu = styled.div`
    font-size: 30px;
    display: none;
    cursor: pointer;
    justify-content: end;
    align-items: center;
    padding-right: 30px;
    width:200px;
    color: white;
    @media (max-width: 1000px) {
        display: flex;
    }
`;

export const CloseMenu = styled.div`
    display:none;
    padding-top: 20px;
    padding-left: 20px;
    color: white;
    font-size: 20px;
    height: 50px;
    cursor: pointer;
    @media (max-width: 1000px) {
        display: flex;
    }
`;

export const NavLinks = styled.div`
    display: flex;
    padding-right: 100px;
    align-items: center;
    justify-content: end;

    @media (max-width: 1000px) {
        flex-direction: column;
        position: fixed; /* Fixar o menu na tela */
        right: 0;
        top: 0;
        height: 100%;
        width: 50%; /* Ajuste conforme necessário */
        background-color: #161616;
        transition: transform 0.3s ease;
        transform: ${props => props.isMenuOpen ? 'translateX(0)' : 'translateX(100%)'};
        z-index: 999; /* Para garantir que o menu sobreponha outros elementos */
        justify-content: top;
    }
`;

export const Ancora = styled(Link)`
    display: flex;
    justify-content: center;
    color: white;
    text-align: center;
    align-items: center;
    cursor: pointer;
    text-decoration: none;
    font-size: 30px;
    width: 25%;

    &:hover{
        background: white;
        color: black;
    }
`

export const ContentSecundario = styled.div `
    height: 300px;
    display: flex;
    justify-content: space-between;
    background-color: white;
    position: fixed;
    z-index: 1;
    top: 0;
    transform: ${props => props.AncoraOvered ? 'translateY(32%)' : 'translateY(-100%)'};
    transition: transform 0.5s ease;
    border-bottom: solid black 5px;
`

export const ContainerSubProdutos = styled.div`
    display: flex;
    flex-direction: row;
`

export const ContentSubProdutos = styled.div`
    display: flex;
    flex-direction: row;
    margin-top: 20px;
    margin-left: 40px;
`

export const ContentSubLinks = styled.div`
     flex-direction: column;
     gap:10px;
`

export const SubLinks = styled.div`
    display: flex;
    font-size: 5px;
    color: black;
    height: 10px;
`


export const TextSubProduto = styled.div`
    font-size: 30px;
    color: black;
    margin-bottom: 50px;
    height: 10px;
    font-family: Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
`

export const Text = styled.div`
    font-size: 15px;
    color: black;
    height: 30px;
    cursor: pointer;

    &:hover{
        text-decoration: underline;
    }
`

export const Icon = styled.div`
  display: inline-flex;
  align-items: center;
  height: 40%;
  width: 20%;
`;
