import { Container } from './styles.js'
import Header from '../../components/Header/index.jsx'
import MostrarProdutos from '../../components/MostrarProduto/index.jsx'
import { useState, useEffect } from 'react';
import api from '../../services/api.js'


function VisualizarProduto(){

    const [objetos, setObjetos] = useState([]);

    const [objetosSelecionados, setObjetosSelecionados] = useState([]);

    const ResgatarObjetos = async () => {
        try {
            const response = await api.get('produto');
            setObjetos(response.data);

        } catch (error) {
            alert('Erro ao resgatar Lista de Objetos: ' + error);
        }
    }
    
    useEffect(()=> {
        ResgatarObjetos();
    },[])


    useEffect(() => {
        if (objetos.length > 0) {
            const produtosIDsString = localStorage.getItem('ProdutosIDs');
            const produtosIDs = produtosIDsString ? JSON.parse(produtosIDsString) : [];
            const objetosSelecionados = objetos.filter(obj => produtosIDs.includes(obj.id));
            setObjetosSelecionados(objetosSelecionados);
        }
    },[objetos]);


    return(
        <Container>
            <Header
                titleName="LOJA ROUPAS"
            />
            <MostrarProdutos
                Objetos={objetosSelecionados}
            />
        </Container>
    )
}
    

export default VisualizarProduto;