import { Box, Typography } from "@mui/material";
import React, { useCallback, useEffect, useState } from "react";
import SearchBar from "../../ui-component/SearchBar";
import RecipeList from "./RecipeList";
import ButtonReusable from "../../ui-component/ButtonReusable";
import {
  listRecipesForCategory,
  searchRecipes,
} from "../../../ApiService/RecipesApi";
import { useParams } from "react-router-dom";
import { recipesBodyStyle } from "../../Style/RecipesBodyStyle";
const RecipesBody = () => {
  const { categoryId } = useParams();
  const [loadMore, setLoadMore] = useState(true);
  const [recipes, setRecipes] = useState([]);
  const [totalAvailableRecipes, setTotalAvailableRecipes] = useState(0);
  const [searchValue, setSearchValue] = useState("");

  const onChangeHandler = (e) => {
    setSearchValue(e.target.value);
    if (e.target.value.length < 3) {
      getInitialRecipes("search");
    } else {
      searchRecipes(
        {
          categoryId,
          searchValue: e.target.value,
          skip: 0,
          pageSize: 9,
        },
        (dataResponse) => {
          if (dataResponse) addingNewRecipes(dataResponse, "search");
        }
      );
    }
  };

  const getInitialRecipes = useCallback(
    (type) => {
      listRecipesForCategory({ categoryId, skip: 0, pageSize: 9 }, (responseData) => {
        if (responseData) addingNewRecipes(responseData, type);
      });
    },
    [categoryId]
  );

  const addingNewRecipes = (response, type) => {
    if (type === "search") {
      setRecipes(response.data);
    } else {
      setRecipes((prevState) => [...prevState, ...response.data]);
    }
    setTotalAvailableRecipes(response.totalDataNumber);
    setLoadMore(response.loadMore);
  };

  const onClickMoreHandler = () => {
    if (searchValue.length > 2) {
      searchRecipes(
        {
          categoryId,
          searchValue,
          skip: recipes.length,
          pageSize: 9,
        },
        (responseData) => {
          if (responseData) addingNewRecipes(responseData);
        }
      );
    } else {
      listRecipesForCategory(
        { categoryId, skip: recipes.length, pageSize: 9 },
        (responseData) => {
          if (responseData) addingNewRecipes(responseData);
        }
      );
    }
  };

  useEffect(() => {
    getInitialRecipes();
  }, [getInitialRecipes]);

  return (
    <React.Fragment>
      <Box sx={recipesBodyStyle}>
        <Typography variant="h5">
          Total recipes: {totalAvailableRecipes}
        </Typography>
        <SearchBar onChangeHandler={onChangeHandler} />
      </Box>
      <RecipeList recipes={recipes} />
      {loadMore && (
        <Box my={2} display="flex" justifyContent="center">
          <ButtonReusable variant="outlined" onClick={onClickMoreHandler}>
            Load more
          </ButtonReusable>
        </Box>
      )}
    </React.Fragment>
  );
};

export default RecipesBody;
