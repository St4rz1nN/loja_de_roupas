import { Container, TamanhoContent } from './styles'

function GerarTamanhos({ Tamanhos, Tamanho, TamanhoSelecionado, onClick }) {

    const handleTamanhoSelecionado = (tamanho) => {
        if(tamanho === TamanhoSelecionado){
            return true;
        }
        return false;
    }


    return(
        <Container>
            {Tamanhos.map(t => {
                return (
                    <TamanhoContent key={t} onClick={()=> onClick(t)} tamanhoselecionado={handleTamanhoSelecionado(t)} tamanho={Tamanho}>{t}</TamanhoContent>
                );
            })}
        </Container>
    )
}


export default GerarTamanhos;