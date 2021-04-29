export interface Produto {
    
    //Código da produto
    cod_produto: number;

    //Código da categoria
    cod_categoria: number;

    //Código de barras
    cod_barras: string;

    //Nome da produto
    nom_produto: string;

    //Ativo [S] ou [N]
    flg_ativo: string;

    //Descrição do produto
    des_produto: string;

    //Valor do produto
    vlr_produto: number;
    
}
