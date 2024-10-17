import styled from "styled-components";
import { Link } from 'react-router-dom';

export const Container = styled.div `
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: row;
    background-color: white;
    padding: 50px;
    padding-left: 300px;
`

export const ContentPhoto = styled.div `
    display: flex;
    height: 100%;
    width: 60%;
    flex-direction: row;
    flex-wrap: wrap;
    padding: 20px;
    gap: 30px;
    justify-content: initial;
`

export const CelulaPhoto = styled.div `
    display: flex;
    background-image: url(${props => props.background});
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
    height: 400px;
    width: 45%;
    border-radius: 30px;
    box-shadow: 0 10px 10px rgba(0, 0, 0, 0.3);
`   

export const ContentProduto = styled.div `
    display: flex;
    height: 100%;
    width: 30%;
    flex-direction: column;
    padding: 20px;
    gap:20px;
`

export const ContentAtributos = styled.div `
    display: flex;
    height: 50%;
    flex-direction: column;
    padding: 20px;
    gap:20px;
    border:1px solid gray;
    border-radius:20px;
`
export const Nome = styled.label `
    align-items: center;
    font-size: 30px;
    font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
    height: 20px;
`
export const Estrelas = styled.label `
    align-items: center;
    font-size: 20px;
    height: 30px;
`

export const Valor = styled.label `
    align-items: center;
    font-size: 30px;
    height: 30px;
`

export const ContentCores = styled.div `
    display: flex;
    height: 50px;
    width: 100%;
    justify-content: initial;
    flex-direction:column;
    gap:10px;
`

export const ContentTamanhos = styled.div `
    margin-top: 20px;
    display: flex;
    height: 50px;
    width: 100%;
    flex-direction:column;
    gap:10px;
`

export const TextAtributos = styled.div `
    align-items: center;
    font-size: 20px;
    font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
    height: 30px;
`

export const ContentQuantia = styled.div `
    margin-top: 20px;
    align-items: center;
    font-size: 20px;
    font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
    height: 50px;
`

export const BotaoCarrinho = styled(Link) `
    display:flex;
    margin-top: 50px;
    align-items: center;
    justify-content: center;
    font-size: 20px;
    font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
    height: 50px;
    width: 350px;
    background-color: ${props=> props.modoAdm ? 'red' : 'black'};
    border-radius: 8px;
    border: 1px solid-black;
    color: white;
    cursor: pointer;
    text-decoration:none;
`

