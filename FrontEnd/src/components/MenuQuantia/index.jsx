import React, { useState } from 'react';
import { Container, Button, CountDisplay } from './styles';


const MenuQuantia = ( { Tamanho, count, onIncrement, onDecrement } ) => {
    return (
      <Container tamanho ={Tamanho}>
        <Button tamanho={Tamanho} onClick={onDecrement}>-</Button>
        <CountDisplay tamanho={Tamanho}>{count}</CountDisplay>
        <Button tamanho={Tamanho} primary onClick={onIncrement}>+</Button>
      </Container>
    );
  };
  
  export default MenuQuantia;