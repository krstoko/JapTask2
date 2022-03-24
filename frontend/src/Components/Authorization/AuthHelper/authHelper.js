const authenticate = (jwt) => {
  if (typeof window !== "undefined") {;
    sessionStorage.setItem("jwt", jwt);
  }
};
const isAuthenticated = () => {
  if (typeof window == "undefined") return false;
  let getToken = sessionStorage.getItem("jwt");

  if (!getToken) {
    return false;
  }
  return true;
};

export { authenticate, isAuthenticated };
