import GerarCores from '../GerarCores';
import GerarTamanhos from '../GerarTamanhos';
import MenuQuantia from '../MenuQuantia/index';
import { Container, ContentPhoto, CelulaPhoto, ContentProduto, ContentCores, ContentTamanhos, TextAtributos, Nome, ContentQuantia, BotaoCarrinho, Estrelas, Valor} from './styles'
import { useState, useEffect } from 'react';
import api from '../../services/api.js';

function MostrarProdutos( { Objetos } ){

    const [count, setCount] = useState(0);
    const [objetoSelecionado, setObjetoSelecionado] = useState([]);
    const [corSelecionada, setCorSelecionada] = useState("");
    const [tamanhoSelecionado, setTamanhoSelecionado] = useState("");
    const [tamanhosDisponiveis, setTamanhosDisponiveis] = useState([]);
    const [coresDisponiveis, setCoresDisponiveis] = useState([]);
    const [fotos, setFotos] = useState([]);
    
    const increment = () => setCount(count + 1);
    const decrement = () => {
        if(count-1 >= 0){
            setCount(count - 1);
        }
    }

    useEffect(() => {
        if (Objetos.length > 0) {
            const primeiroObjeto = Objetos[0];
            setObjetoSelecionado(primeiroObjeto);
            setCorSelecionada(primeiroObjeto.cor);
            setTamanhoSelecionado(primeiroObjeto.tamanho);
            handleTamanhosPorCorSelecionada(primeiroObjeto.cor);
            setCoresDisponiveis([...new Set(Objetos.map(obj => obj.cor))]);

            const resgatarFotos = async () => {
                try{
                    console.log(Objetos[0].id);
                    const response = await api.get(`produto/foto/${Objetos[0].id}`);
                    const data = response.data;
                    console.log(data)
                    setFotos(data);
                }catch(error){
                    console.log('Erro ao resgatar Foto: ' + error);
                }
            }
            resgatarFotos();
        }
    },[Objetos]);
    
    const handleObjetoSelecionado = (objeto) => {
        setObjetoSelecionado(objeto);
        setCorSelecionada(objeto.cor);
        setTamanhoSelecionado(objeto.tamanho);
        handleTamanhosPorCorSelecionada(objeto.cor);
    };

    const handleTamanhosPorCorSelecionada = (Cor) => {
        const tamanhosDisponiveis = [...new Set(Objetos.filter(objeto => objeto.cor == Cor).map(objeto=> objeto.tamanho))]
        setTamanhosDisponiveis(tamanhosDisponiveis);
        handleTamanhoSelecionado(tamanhosDisponiveis[0])
    }

    const handleCorSelecionada = (cor) => {
        setCorSelecionada(cor);
        handleTamanhosPorCorSelecionada(cor);
    }

    const handleTamanhoSelecionado = (tamanho) => {
        setTamanhoSelecionado(tamanho);
    }

    return(
        <Container>
            <ContentPhoto>
                {fotos.map(foto => {
                    return(
                        <CelulaPhoto key={foto.fileName}>
                            <img
                                src={foto.dataUrl}
                                alt={foto.fileName}
                                style={{ width: '100%', height: '100%' }}
                            />
                        </CelulaPhoto>
                    )
                })}
            </ContentPhoto>

            <ContentProduto>

                <Nome>{objetoSelecionado.nome}</Nome>
                <Estrelas>★★★★★ 5.0</Estrelas>
                <Valor>
                    R$ {objetoSelecionado.valor}
                </Valor>
                <ContentCores>
                    <TextAtributos>Cores</TextAtributos>
                    <GerarCores
                        Cores={coresDisponiveis}
                        CorSelecionada={corSelecionada}
                        Tamanho= {30}
                        onClick={handleCorSelecionada}
                    />
                </ContentCores>
                <ContentTamanhos>
                    <TextAtributos>Tamanhos</TextAtributos>
                    <GerarTamanhos
                        Tamanhos={tamanhosDisponiveis}
                        TamanhoSelecionado={tamanhoSelecionado}
                        Tamanho={30}
                        onClick={handleTamanhoSelecionado}
                    />
                </ContentTamanhos>
                <ContentQuantia>
                    <TextAtributos>Quantidade</TextAtributos>
                    <MenuQuantia
                        Tamanho={150}
                        count={count}
                        onIncrement={increment}
                        onDecrement={decrement}
                    />
                </ContentQuantia>
                <BotaoCarrinho>
                    ADICIONAR AO CARRINHO
                </BotaoCarrinho>
            </ContentProduto>
        </Container>

    )
}

export default MostrarProdutos;