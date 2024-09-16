import React, { useState, useEffect } from 'react';
import api from '../../services/api'; // Ajuste o caminho conforme necessário

const GerarImagem = ({ FotoURL }) => {
  const [imageUrl, setImageUrl] = useState(null);
  const [reloadCounter, setReloadCounter] = useState(0); 
  
  useEffect(() => {
    if (FotoURL){
      const splitURL = FotoURL.split("Storage\\")
      const fileName = splitURL[1];

      const resgatarFoto = async () => {
        console.log("filename: " + fileName)
        if(fileName){
          try{
              const response = await api.get(`produto/foto/${fileName}`);
              const data = response.data;
              setImageUrl(data.image);
              
          }catch(error){
              console.log('Erro ao resgatar Foto: ' + error);
          }
        }
      }
      resgatarFoto();
    }
  }, [FotoURL]);

  return (
    <div>
      {imageUrl ? (
        <img src={imageUrl} style={{ maxWidth: '100%', height: '100%' }} />
      ) : (
        <p>Carregando imagem...</p>
      )}
    </div>
  );
};

export default GerarImagem;