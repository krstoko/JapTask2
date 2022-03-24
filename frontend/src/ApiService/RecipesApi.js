import api from "./AxiosConfigure";

const listRecipesForCategory = (data, cb) => {
  api
    .get(`/recipes`, {
      params: data,
    })
    .then((response) => cb(response.data))
    .catch((err) => {
      console.log(err);
      cb(false);
    });
};

const searchRecipes = (data, cb) => {
  api
    .get(`/recipes/search`, {
      params: data,
    })
    .then((response) => cb(response.data))
    .catch((err) => {
      console.log(err);
      cb(false);
    });
};

const singleRecipe = (recipeId, cb) => {

  api
    .get(`/recipes/${recipeId}`)
    .then((response) => cb(response.data))
    .catch((err) => {
      console.log(err);
      cb(false);
    });
};
const addRecipe = (recipe,cb) => {
  api
  .post(`/recipes`,recipe)
  .then((response) => cb(response.data))
  .catch((err) => {
    console.log(err);
    cb(false);
  });
};
export { listRecipesForCategory, searchRecipes, singleRecipe, addRecipe };
