import styled from "styled-components";


export const Container = styled.label `
    display: flex;
    width: 100%;
    height: 100%;
    flex-direction: row;
    gap: 5px;
`

const corParaValor = {
    'vermelho': 'red',
    'azul': 'blue',
    'verde': 'green',
    'amarelo': 'yellow',
    'preto': 'black',
    'branco': 'white',
};

export const Cor = styled.label `
    background-color: ${props => corParaValor[props.nomeCor.toLowerCase()] || 'transparent'};
    width: ${props => props.tamanho}px;
    height: ${props => props.tamanho}px;
    border-radius: ${props => props.tamanho/1.5}px;
    border: ${props => props.corSelecionada ? `${props.tamanho/15}px solid rgba(0, 0, 0, 0.5)` : `${props.tamanho/20}px solid rgba(0, 0, 0, 0.5)`};
    cursor:pointer;
`