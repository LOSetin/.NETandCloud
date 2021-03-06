
var lExpend = "lminus.gif";
var lPinch = "lplus.gif";   
var tExpend = "tminus.gif";
var tPinch = "tplus.gif";         

function ClickNode(img,isBottom,tableId)
{
    var imgId = img.src.substring(img.src.lastIndexOf("/")+1);
    var url = img.src.substring(0,img.src.lastIndexOf("/")+1);
    var oldTrId = img.parentElement.parentElement.id;
    var newTrId = oldTrId.substring(oldTrId.indexOf("_")+1);
    
    if( isBottom)
    {
        if( imgId == lExpend)
        {
            img.src =  url+ lPinch;
            img.parentElement.id = lPinch;
            PinchNode(newTrId,oldTrId,tableId);
        }
        else
        {
            img.src = url + lExpend;
            img.parentElement.id = lExpend;
            ExpendNode(newTrId,oldTrId,tableId);
        }   
    }
    else
    {
        if( imgId == tExpend )
        {
            img.src =  url+ tPinch;
            img.parentElement.id = tPinch;
            PinchNode(newTrId,oldTrId,tableId);
      
        }
        else
        {
            img.src = url + tExpend;
            img.parentElement.id = tExpend;
            ExpendNode(newTrId,oldTrId,tableId);
        }   
    }
}

function ExpendNode(newId,oldId,tableId)
{
    var tree = document.getElementById(tableId);
    for( var i = 0; i < tree.rows.length; i++ )
    {
        //逐层展开子节点
        if( tree.rows[i].id.indexOf(newId) != -1 && tree.rows[i].id != oldId && tree.rows[i].id.split("/").length==oldId.split("/").length+1)
        {
            var isExpend = true;
            var pId = tree.rows[i].id;
           
            while( pId != oldId)
            {
                for( var j = 0; j < 2; j++ )
                    pId = pId.substring( 0,pId.lastIndexOf("/"));
                var parent = document.getElementById(pId);
                if( parent != null )
                {
                    var tempId = parent.cells[2].id;
                    if( tempId == lExpend || tempId == tExpend || tempId == "")
                        ;
                    else
                    {
                        isExpend = false;
                        break;
                    }
                }
                else
                    break;
            }
            if( isExpend )
               tree.rows[i].style.display="";  
        }
    }
}

function PinchNode(newId,oldId,tableId)
{
    var tree = document.getElementById(tableId);
    for( var i = 0; i < tree.rows.length; i++ )
    {
        
        if( tree.rows[i].id.indexOf(newId) != -1 && tree.rows[i].id != oldId)
        {
            tree.rows[i].style.display = "none";
            //收起的时候，如果含有子节点，则图标变成+
            var hasChild = false;
            for (var j = 0; j < tree.rows.length; j++)
            {
                if (tree.rows[j].id.indexOf(tree.rows[i].id) != -1 && tree.rows[j].id != tree.rows[i].id)
                {
                    hasChild = true;
                    break;
                }
            }
            if (hasChild) {
                var curRow = document.getElementById(tree.rows[i].id);
                var imgs = curRow.getElementsByTagName("IMG");
                for (var k = 0; k < imgs.length; k++)
                {
                    var img = imgs[k];
                    var url = img.src.substring(0, img.src.lastIndexOf("/") + 1);
                    var imgId = img.src.substring(img.src.lastIndexOf("/") + 1);
                    if (imgId == lExpend) {
                        img.src = url + lPinch;
                    }
                    if (imgId == tExpend) {
                        img.src = url + tPinch;
                    }
                }
            }
        }
    }
}