import api from "./AxiosConfigure";
const listCategories = (skip, pageSize, cb) => {
  api
    .get("/categories/getPage", {
      params: {
        skip: skip,
        pageSize: pageSize,
      },
    })
    .then((response) => cb(response.data))
    .catch((err) => {
      console.log(err);
      cb(false);
    });
};

const getAllCategories = (cb) => {
  api
    .get("/categories")
    .then((response) => cb(response.data))
    .catch((err) => {
      console.log(err);
      cb(false);
    });
};

export { listCategories, getAllCategories };
