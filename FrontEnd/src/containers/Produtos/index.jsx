import { Container, Content, ContentHeader, ContentListagem, ContentMenuFiltro } from './styles.js'
import Header from '../../components/Header/index.jsx'
import Listagem from '../../components/Listagem/index.jsx';
import MenuFiltro from '../../components/MenuFiltro/index.jsx'
import Modal from '../../components/Modal/index.jsx'
import { TextSubFiltro } from '../../components/MenuFiltro/styles.js';
import { use } from 'react';
import { useState, useEffect } from 'react';

import api from '../../services/api.js'
import { SiTruenas } from 'react-icons/si';

function Produtos() {


  const filtrosComponent = [
    {
      nome: "TIPO",
      subfiltro: ["Camisa", "Camiseta", "TacTel", "Calças"]
    },
    {
      nome: "TAMANHO",
      subfiltro: ["PP", "P", "M", "G", "GG"]
    },
    {
      nome: "COR",
      subfiltro: ["Preto", "Branco", "Azul", "Verde", "Amarelo", "Vermelho"]
    },
  
  ];

  const [objetos, setObjetos] = useState([]);
  const [produtosFiltrados, setProdutosFiltrados] = useState([]);


  //Modal
  const [modoAdm, setModoAdm] = useState(false);
  const [modalVisivel, setModalVisivel] = useState(true);
  const [tipoModal, setTipoModal] = useState("Carregando");
  const [mensagemModal, setMensagemModal] = useState("");
  const [textTamanho, setTextTamanho] = useState(40);
  const [modalHeight, setModalHeight] = useState(300);
  const [modalWidth, setModalWidth] = useState(600);
  const handleModal = (Tipo, Mensagem, Height, Width, TextTamanho) => {
    setTipoModal(Tipo);
    setMensagemModal(Mensagem);
    setModalVisivel(true);
    setModalHeight(Height)
    setModalWidth(Width)
    setTextTamanho(TextTamanho)
  }
  const closeModal = () => {
    setModalVisivel(false);
  };

  const ResgatarObjetos = async () => {
    try{
      const response = await api.get('produto');
      console.log("Resposta da API:", response.data);
      setObjetos(response.data);
      setModalVisivel(false);
    }catch(error){
      handleModal("Alerta", `Erro ao resgatar Lista de Objetos: + ${error}`,300,600,20)
    }
  }

  useEffect(()=> {
    ResgatarObjetos();
    const valorRecuperado = JSON.parse(localStorage.getItem('modoadm'));
    console.log("Valor Recuperado: " + valorRecuperado)
    if(valorRecuperado == true){
      setModoAdm(true);
      console.log("TESTER SETTER")
    }
  },[])

  useEffect(() => {
    setProdutosFiltrados(objetos);
    console.log("Produtos Filtrados Atualizados:", objetos);
  }, [objetos]);

  const handleProdutosFiltrados = (produtosFiltrados) => {
    setProdutosFiltrados(produtosFiltrados);
  }


  return (
      <Container>
          <Header
              administrador={modoAdm}
              subLinks={!modoAdm}
          />
          <Modal
            Height={modalHeight}
            Width={modalWidth}
            Tipo={tipoModal}
            Mensagem={mensagemModal}
            Visivel={modalVisivel}
            TextTamanho={textTamanho}
            OnClick={closeModal}
          />
          <Content>
            <ContentMenuFiltro>
              <MenuFiltro
                Filtros={filtrosComponent}
                Objetos={objetos}
                onProdutosFiltrados={handleProdutosFiltrados}
              />
            </ContentMenuFiltro>
            <ContentListagem>
              <Listagem
                  Objetos={produtosFiltrados}
                  Filtros={filtrosComponent}
                  ModoAdm={modoAdm}
              />
             </ContentListagem>
          </Content>
      </Container>
  )
}

export default Produtos;
