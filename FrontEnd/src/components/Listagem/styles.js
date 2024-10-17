import styled from "styled-components";
import background from '../../assets/images/background.png'

export const Container = styled.div `
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    background-color: white;
`

export const Celula = styled.div `
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    height: 500px;
    width: 24%;
    cursor: pointer;
    transition: transform 0.2s ease-in-out;
    border: ${props => props.modoAdm ? "2px solid red" : "1px transparent"};

    &:hover{
        transform: scale(1.03);
    }
`

export const ButtonEdit = styled.button `
    position: absolute;
    width:30px;
    height:30px;
    top: 5px;
    right: 5px;
    background: rgba(255, 255, 255, 1); // Fundo semi-transparente
    border: 1px transparent;
    border-radius: 5px;
    padding: 5px;
    cursor: pointer;
    zIndex: 1; // Garante que o botão fique acima da imagem
    transition: transform ease 0 s.2;

    &:hover{
        transform:scale(1.1)
    }
`   

