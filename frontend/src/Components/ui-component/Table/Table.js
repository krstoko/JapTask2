import * as React from "react";
import { DataGrid } from "@mui/x-data-grid";
import { Box } from "@mui/material";

const Table = (props) => {

    const style = {
        width: "100%",
        height: 400,
        pt: 3
    }
  return (
      <Box component="div" sx={style}>
      <DataGrid
        rows={props.rows}
        columns={props.columns}
        pageSize={5}
        rowsPerPageOptions={[5]}
        disableColumnMenu
        disableSelectionOnClick
      />
      </Box>
  );
};

export default Table;
