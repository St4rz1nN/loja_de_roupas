
import { Container, ContentFiltro, ContentSubFiltro, TextFiltro, TextSubFiltro, CheckBox } from './styles.js'
import { useState } from 'react';

const MenuFiltro = ({Filtros, Objetos, onProdutosFiltrados}) => {

    const [filtros, setFiltros] = useState([{}]);

    const handleFiltro = (nome, subfiltro, event) => {
        const isChecked = event.target.checked;
        let filtrosAtuais = filtros;
        if(isChecked){
            const filtroselecionado = filtrosAtuais.find(item => item.nome == nome);
            if (filtroselecionado){
                filtrosAtuais.map(item => {
                    if(item.nome == nome){
                        item.subfiltros.push(subfiltro);
                    }
                });
            }else{
                const subfiltros = [];
                subfiltros.push(subfiltro)
                filtrosAtuais.push({nome, subfiltros});
            }
            setFiltros(filtrosAtuais);
        }else{
            filtrosAtuais.map(item => {
                if(item.nome == nome){
                    item.subfiltros = item.subfiltros.filter(subItem => subItem !== subfiltro);
                }
            })
            setFiltros(filtrosAtuais);
        }
        filtrarObjetos();
    };

    const filtrarObjetos = () => {
        var objetosFiltrados = [];
        var subFiltroEncontrado = false;
        var subFiltroEquivalente = 0;
        var quantiaSubFiltrosEncontrados = 0;
        Objetos.map(objeto => {
            subFiltroEquivalente = 0;
            quantiaSubFiltrosEncontrados = 0;
            filtros.map(filtro => {
                if(filtro.nome){
                    const atributoFiltro = filtro.nome.toLowerCase();
                    for (const chave in objeto){
                        if(chave.toLowerCase() === atributoFiltro){
                            if (filtro.subfiltros && filtro.subfiltros.length > 0){
                                quantiaSubFiltrosEncontrados = quantiaSubFiltrosEncontrados + 1;
                                subFiltroEncontrado = true;
                                filtro.subfiltros.map(subfiltro => {
                                    if (objeto[filtro.nome.toLowerCase()].toLowerCase() === subfiltro.toLowerCase()){
                                        subFiltroEquivalente = subFiltroEquivalente+1;
                                    }
                                }
                                )
                            }
                        }
    
                    }
                }
            })
            if (subFiltroEquivalente == quantiaSubFiltrosEncontrados){
                objetosFiltrados.push(objeto);
            }
        });
        if(!subFiltroEncontrado){
            objetosFiltrados=Objetos;
        }
        onProdutosFiltrados(objetosFiltrados);
    }

    return (
        <Container>
            {Filtros.map(Filtro =>
                <ContentFiltro key={Filtro.nome}>
                    <TextFiltro key={Filtro.nome}>{Filtro.nome}</TextFiltro>
                    <ContentSubFiltro>
                        {Filtro.subfiltro && Filtro.subfiltro.length > 0 ? (
                            Filtro.subfiltro.map(SubFiltro =>
                                <TextSubFiltro key={SubFiltro}>
                                    <CheckBox onClick={(event) => handleFiltro(Filtro.nome, SubFiltro, event)}/>
                                    {SubFiltro}
                                </TextSubFiltro>
                            )
                        ) : null}
                    </ContentSubFiltro>
                </ContentFiltro>
            )};
        </Container>
    )
}

export default MenuFiltro;