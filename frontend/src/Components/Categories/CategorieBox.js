import {
  Box,
  Card,
  CardActionArea,
  CardMedia,
  Grid,
  Typography,
} from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";
import { style } from "./CategorieBoxStyle";

const CategorieBox = ({ category }) => {
  const navigate = useNavigate();

  const onCardClick = () => {
    navigate(`/recipes/${category.id}`);
  };

  return (
    <Grid item xs={12} sm={6} md={4}>
      <Card>
        <CardActionArea onClick={onCardClick}>
          <Box sx={style.boxWrapper}>
            <CardMedia component="img" height="200" image={category.imgUrl} />
            <Box sx={style.textBox}>
              <Typography variant="h5" align="center">
                {category.name}
              </Typography>
            </Box>
          </Box>
        </CardActionArea>
      </Card>
    </Grid>
  );
};

export default CategorieBox;
