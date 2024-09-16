
import {Container, Celula } from './styles.js'

import Produto from '../../components/Produto'

const Listagem = ({Objetos, Filtros}) => {

    const nomesVistos = new Set();

    const objetosUmPorNome = Objetos.filter(Objeto => {
        if(!nomesVistos.has(Objeto.nome)){
            nomesVistos.add(Objeto.nome);
            return true;
        }
        return false;
    });

    const handleFiltrosPorProduto = (nome) => {
        const tamanhos = [];
        const cores = [];
        Objetos.map(O => {
            if(O.nome == nome){
                for (const chave in O){
                    const atributoObjeto = chave.toLowerCase();
                    Filtros.map(Filtro => {
                        const atributoFiltro = Filtro.nome.toLowerCase();
                        if(atributoObjeto === atributoFiltro){
                            if(Filtro.subfiltro && Filtro.subfiltro.length >0){
                                Filtro.subfiltro.map(subfiltro =>{
                                    if(subfiltro == O[chave]){
                                        if(Filtro.nome.toLowerCase() === "tamanho"){
                                            if(!tamanhos.includes(subfiltro)){
                                                tamanhos.push(subfiltro);
                                            }
                                        }else{
                                            if(!cores.includes(subfiltro)){
                                                cores.push(subfiltro);
                                            }
                                        }
                                    }
                                })
                            }
                        }
                    })
                }
            }
        })
        return {tamanhos, cores};
    }
    const handlePodutosId = (nome) => {
        const produtosIDs = [...new Set(Objetos.filter(objeto => objeto.nome == nome).map(objeto=> objeto.id))]
        localStorage.setItem('ProdutosIDs',JSON.stringify(produtosIDs));
    }

    return (
        <Container>
            {objetosUmPorNome.map(objeto =>
                {
                const {tamanhos, cores} = handleFiltrosPorProduto(objeto.nome)
                return(
                    <Celula key={objeto.nome} onClick={() => handlePodutosId(objeto.nome)}>
                        <Produto
                            Objeto={objeto}
                            Tamanhos={tamanhos}
                            Cores={cores}
                        />
                    </Celula>
                )
            }
            )}
        </Container>
    )
}

export default Listagem;