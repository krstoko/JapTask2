import api from "./AxiosConfigure";

const login = (credentials, cb) => {
  api
    .post("/auth/login", credentials)
    .then((response) => cb(response.data))
    .catch((err) => {
      console.log(err);
      cb(false);
    });
};

export { login };
