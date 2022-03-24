import api from "./AxiosConfigure";

const getAllIngredients = (cb) => {
  api
    .get("/ingredients")
    .then((response) => cb(response.data))
    .catch((err) => {
      console.log(err);
      cb(false);
    });
};

export {  getAllIngredients };
