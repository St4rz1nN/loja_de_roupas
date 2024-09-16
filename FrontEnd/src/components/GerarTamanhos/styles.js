import styled from "styled-components";


export const Container = styled.label `
    display: flex;
    width: 100%;
    height: 100%;
    flex-direction: row;
    gap: 5px;
`

export const TamanhoContent = styled.label `
    display: flex;
    color: ${props => props.tamanhoselecionado ? 'white':'black'};
    font-size: ${props => props.tamanho/1.5}px;
    width: ${props => props.tamanho}px;
    height: ${props => props.tamanho}px;
    border-radius: ${props => props.tamanho/5}px;
    border: ${props => props.tamanho/15}px white;
    justify-content: center;
    align-items: center;
    background-color: ${props => props.tamanhoselecionado ? 'black':'rgb(0,0,0,0.05)'};
    cursor: pointer;
`