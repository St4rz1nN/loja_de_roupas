import { Container, Cor } from './styles'

function GerarCores({ Cores, Tamanho, CorSelecionada, onClick }) {

    const handleCorSelecionada = (cor) => {
        if(cor === CorSelecionada){
            return true;
        }
        return false;
    }

    return(
        <Container>
            {Cores.map(cor => {
                return (
                    <Cor key={cor} onClick={()=>onClick(cor)} nomeCor={cor} corSelecionada={handleCorSelecionada(cor)} tamanho={Tamanho} tamanhoSelecionado={"M"}></Cor>
                );
            })}
        </Container>
    )
}


export default GerarCores;