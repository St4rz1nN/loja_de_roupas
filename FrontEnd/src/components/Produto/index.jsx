
import { Container, Photo, ContentAtributos, NomeText, ContentTamanho, Tamanho, PrecoText } from './styles.js'
import GerarCores from '../GerarCores/index.jsx';
import GerarTamanhos from '../GerarTamanhos/index.jsx';
import { useState, useEffect } from 'react';
import api from '../../services/api.js'

const Produto = ({ Objeto, Tamanhos, Cores }) => {

    const [foto, setFoto] = useState({});

    useEffect(() => {
        if(Objeto.id != null){
            const resgatarFotos = async () => {
                try{
                    console.log(Objeto.id);
                    const response = await api.get(`produto/foto/${Objeto.id}`);
                    const data = response.data;
                    console.log(data[0].dataUrl)
                    setFoto(data[0]);
                }catch(error){
                    console.log('Erro ao resgatar Foto: ' + error);
                }
            }
            resgatarFotos();
        }
    }, [Objeto]);

    return (
        <Container key={Objeto.nome} to="/visualizarproduto">
            <Photo>
                <img
                    src={foto.dataUrl}
                    alt={foto.fileName}
                    style={{ maxWidth: '100%', maxHeight: '100%' }}
                />
            </Photo>
            <ContentAtributos>
                <NomeText>{Objeto.nome}</NomeText>
                <GerarTamanhos
                    Tamanhos={Tamanhos}
                    Tamanho={15}
                />
                <GerarCores
                    Cores={Cores}
                    Tamanho={15}
                />
                <PrecoText>R$ {Objeto.valor}</PrecoText>
            </ContentAtributos>
        </Container>
    )
}

export default Produto;