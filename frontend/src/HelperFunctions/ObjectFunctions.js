export const renameObjKey = (array, keyOld, keyNew) => {
    array = array.map((obj) => {
      obj[keyNew] = obj[keyOld];
      delete obj[keyOld];
      return obj;
    });
    return array;
  };
  