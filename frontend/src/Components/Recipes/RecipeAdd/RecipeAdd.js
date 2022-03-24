import React from 'react';
import { useNavigate } from 'react-router-dom';
import ContainerPaper from '../../ui-component/ContainerPaper';
import Header from '../../ui-component/Header';
import RecipeAddBody from './RecipeAddBody';

const RecipeAdd = () => {
    const navigate = useNavigate();

    const onBackClick = () =>{
        navigate("/categories")
    }
    return (
        <ContainerPaper maxWidth="lg">
            <Header onBackClick={onBackClick}/>
            <RecipeAddBody />
        </ContainerPaper>
    );
};

export default RecipeAdd;