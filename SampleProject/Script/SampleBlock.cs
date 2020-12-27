using UnityEngine;

// "SampleProject" here is the Assembly name of this project.
// <property name="Class" value="SampleBlock, SampleProject"/>

// The Block loading in the game requires it to start with Block in the class name. The game adds this itself, so do not add it to the XML's Class value
class BlockSampleBlock : Block
{
    public override void OnBlockAdded(WorldBase _world, Chunk _chunk, Vector3i _blockPos, BlockValue _blockValue)
    {
        Debug.Log("SampleBlock: OnBlockAdded(): " + GetBlockName());
        base.OnBlockAdded(_world, _chunk, _blockPos, _blockValue);

    }
}

